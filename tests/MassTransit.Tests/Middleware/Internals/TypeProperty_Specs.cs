﻿namespace MassTransit.Tests.Middleware.Internals
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using MassTransit.Internals;
    using NUnit.Framework;


    [TestFixture]
    public class Working_with_the_properties_of_a_type
    {
        [Test]
        public void Should_include_properties_from_the_base_class()
        {
            IEnumerable<PropertyInfo> properties = typeof(B).GetAllProperties();

            Assert.That(properties.Count(), Is.EqualTo(3));
        }

        [Test]
        public void Should_include_properties_from_the_interface()
        {
            IEnumerable<PropertyInfo> properties = typeof(C).GetAllProperties();

            Assert.That(properties.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Should_include_properties_from_the_interface_and_base_interfaces()
        {
            IEnumerable<PropertyInfo> properties = typeof(D).GetAllProperties();

            Assert.That(properties.Count(), Is.EqualTo(4));
        }

        [Test]
        public void Should_include_properties_from_the_interface_and_such()
        {
            IEnumerable<PropertyInfo> properties = typeof(ID).GetAllProperties();

            Assert.That(properties.Count(), Is.EqualTo(4));
        }

        [Test]
        public void Should_include_static_properties()
        {
            IEnumerable<PropertyInfo> properties = typeof(A).GetAllStaticProperties();

            Assert.That(properties.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Should_include_static_properties_of_base_classes()
        {
            IEnumerable<PropertyInfo> properties = typeof(B).GetAllStaticProperties();

            Assert.That(properties.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Should_include_the_properties_on_the_class()
        {
            IEnumerable<PropertyInfo> properties = typeof(A).GetAllProperties();

            Assert.That(properties.Count(), Is.EqualTo(2));
        }


        class A
        {
            public string One { get; set; }
            public string Two { get; set; }

            public static string Alpha { get; set; }
        }


        class B :
            A
        {
            public string Three { get; set; }
        }


        interface IC
        {
            string Four { get; set; }
            string Five { get; set; }
        }


        class C :
            IC
        {
            public string Four { get; set; }
            public string Five { get; set; }
        }


        interface ID :
            IC
        {
            string Six { get; set; }
            string Seven { get; set; }
        }


        class D :
            ID
        {
            public string Four { get; set; }
            public string Five { get; set; }
            public string Six { get; set; }
            public string Seven { get; set; }
        }
    }
}
