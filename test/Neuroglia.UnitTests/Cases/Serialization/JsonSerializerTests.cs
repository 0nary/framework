﻿using FluentAssertions;
using Microsoft.Extensions.Options;
using Neuroglia.UnitTests.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using JsonSerializer = Neuroglia.Serialization.JsonSerializer;

namespace Neuroglia.UnitTests.Cases.Serialization
{
    public class JsonSerializerTests
    {

        protected JsonSerializer Serializer { get; } = new JsonSerializer(Options.Create(new JsonSerializerOptions()));

        [Fact]
        public async Task SerializeAndDeserialize_ShouldWork()
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

    }

}
