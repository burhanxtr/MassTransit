﻿namespace MassTransit.MartenIntegration.Tests
{
    using System;


    public class SimpleSagaMessageBase : CorrelatedBy<Guid>
    {
        public SimpleSagaMessageBase()
        {
        }

        public SimpleSagaMessageBase(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; set; }
    }


    [Serializable]
    public class InitiateSimpleSaga : SimpleSagaMessageBase
    {
        public InitiateSimpleSaga()
        {
        }

        public InitiateSimpleSaga(Guid correlationId)
            : base(correlationId)
        {
        }

        public string Name { get; set; }
    }


    [Serializable]
    public class ObservableSagaMessage
    {
        public string Name { get; set; }
    }


    [Serializable]
    public class CompleteSimpleSaga : SimpleSagaMessageBase
    {
        public CompleteSimpleSaga()
        {
        }

        public CompleteSimpleSaga(Guid correlationId)
            : base(correlationId)
        {
        }
    }
}
