﻿using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Neuroglia.Serialization;
using Neuroglia.UnitTests.Data;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Neuroglia.UnitTests.Cases.Serialization
{

    public class YamlDotNetSerializerTests
    {

        public YamlDotNetSerializerTests()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddYamlDotNetSerializer(serializer => serializer.WithTypeConverter(new YamlDotNet.Serialization.UriTypeConverter()), deserializer => deserializer.WithTypeConverter(new YamlDotNet.Serialization.UriTypeConverter()));
            this.Serializer = services.BuildServiceProvider().GetRequiredService<YamlDotNetSerializer>();
        }

        protected YamlDotNetSerializer Serializer { get; }

        [Fact]
        public async Task SerializeAndDeserialize_ComplexObject_ShouldWork()
        {
            //arrange
            var toSerialize = new TestAddress()
            {
                Street = "Fake Street",
                PostalCode = "Fake Postal Code",
                City = "Fake City",
                Country = "Fake Country"
            };

            //act
            var buffer = await this.Serializer.SerializeAsync(toSerialize);
            var deserialized = await this.Serializer.DeserializeAsync<TestAddress>(buffer);

            //assert
            deserialized.Should().NotBeNull();
            deserialized.Street.Should().Be(toSerialize.Street);
            deserialized.PostalCode.Should().Be(toSerialize.PostalCode);
            deserialized.City.Should().Be(toSerialize.City);
            deserialized.Country.Should().Be(toSerialize.Country);
        }

        [Fact]
        public async Task SerializeAndDeserialize_Uri_ShouldWork()
        {
            //arrange
            var toSerialize = new Uri("http://fake.com");

            //act
            var buffer = await this.Serializer.SerializeAsync(toSerialize);
            var deserialized = await this.Serializer.DeserializeAsync<Uri>(buffer);

            //assert
            deserialized.Should().NotBeNull();
            deserialized.Should().Be(toSerialize);
        }

    }

}
