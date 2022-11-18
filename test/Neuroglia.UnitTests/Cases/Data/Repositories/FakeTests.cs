using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Neuroglia.Data;
using Neuroglia.UnitTests.Containers;
using Neuroglia.UnitTests.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Neuroglia.UnitTests.Cases.Data.Repositories
{

    [TestCaseOrderer("Xunit.PriorityTestCaseOrderer", "Neuroglia.Xunit")]
    public sealed class FakeTests
    {

        [Fact, Priority(1)]
        public void Test()
        {
            Assert.True(true);
        }

    }

}
