﻿namespace MassTransit.RabbitMqTransport
{
    using System;
    using System.Threading.Tasks;
    using Configuration;
    using Middleware;
    using Transports;


    public class ConnectionContextSupervisor :
        TransportPipeContextSupervisor<ConnectionContext>,
        IConnectionContextSupervisor
    {
        readonly IRabbitMqHostConfiguration _hostConfiguration;
        readonly IRabbitMqTopologyConfiguration _topologyConfiguration;

        public ConnectionContextSupervisor(IRabbitMqHostConfiguration hostConfiguration, IRabbitMqTopologyConfiguration topologyConfiguration)
            : base(new ConnectionContextFactory(hostConfiguration))
        {
            _hostConfiguration = hostConfiguration;
            _topologyConfiguration = topologyConfiguration;
        }

        public Uri NormalizeAddress(Uri address)
        {
            return new RabbitMqEndpointAddress(_hostConfiguration.HostAddress, address);
        }

        public Task<ISendTransport> CreateSendTransport(RabbitMqReceiveEndpointContext receiveEndpointContext,
            IModelContextSupervisor modelContextSupervisor, Uri address)
        {
            LogContext.SetCurrentIfNull(_hostConfiguration.LogContext);

            var endpointAddress = new RabbitMqEndpointAddress(_hostConfiguration.HostAddress, address);

            TransportLogMessages.CreateSendTransport(endpointAddress);

            var settings = _topologyConfiguration.Send.GetSendSettings(endpointAddress);

            var brokerTopology = settings.GetBrokerTopology();

            var configureTopology = new ConfigureRabbitMqTopologyFilter<SendSettings>(settings, brokerTopology);

            return CreateSendTransport(receiveEndpointContext, modelContextSupervisor, configureTopology, settings.ExchangeName, endpointAddress);
        }

        public Task<ISendTransport> CreatePublishTransport<T>(RabbitMqReceiveEndpointContext receiveEndpointContext,
            IModelContextSupervisor modelContextSupervisor)
            where T : class
        {
            LogContext.SetCurrentIfNull(_hostConfiguration.LogContext);

            IRabbitMqMessagePublishTopology<T> publishTopology = _topologyConfiguration.Publish.GetMessageTopology<T>();

            var settings = publishTopology.GetSendSettings(_hostConfiguration.HostAddress);

            var brokerTopology = publishTopology.GetBrokerTopology();

            var configureTopology = new ConfigureRabbitMqTopologyFilter<SendSettings>(settings, brokerTopology);

            var endpointAddress = settings.GetSendAddress(_hostConfiguration.HostAddress);

            return CreateSendTransport(receiveEndpointContext, modelContextSupervisor, configureTopology, publishTopology.Exchange.ExchangeName,
                endpointAddress);
        }

        Task<ISendTransport> CreateSendTransport(ReceiveEndpointContext receiveEndpointContext, IModelContextSupervisor modelContextSupervisor,
            ConfigureRabbitMqTopologyFilter<SendSettings> filter, string exchangeName, RabbitMqEndpointAddress endpointAddress)
        {
            var supervisor = new ModelContextSupervisor(modelContextSupervisor);

            var delaySettings = endpointAddress.GetDelaySettings();

            IPipe<ModelContext> delayPipe = new ConfigureRabbitMqTopologyFilter<DelaySettings>(delaySettings, delaySettings.GetBrokerTopology()).ToPipe();

            var sendTransportContext = new RabbitMqSendTransportContext(_hostConfiguration, receiveEndpointContext, supervisor, filter, exchangeName,
                delayPipe, delaySettings.ExchangeName);

            var transport = new SendTransport<ModelContext>(sendTransportContext);

            modelContextSupervisor.AddSendAgent(transport);

            return Task.FromResult<ISendTransport>(transport);
        }
    }
}
