using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Neuroglia.Caching;
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
    public sealed class FakeTests :
        IDisposable
    {

        public FakeTests()
        {
            ServiceCollection services = new();
            services.AddLogging();
            services.AddSingleton(provider => Cache);
            services.AddDistributedCacheRepository<TestPerson, Guid>();
            this.ServiceScope = services.BuildServiceProvider().CreateScope();
            //this.Repository = this.ServiceScope.ServiceProvider.GetRequiredService<DistributedCacheRepository<TestPerson, Guid>>();
        }
        IServiceScope ServiceScope { get; }
        static readonly IDistributedCache Cache = new MemoryDistributedCache(new MemoryCache(Options.Create(new MemoryCacheOptions())));

        [Fact, Priority(1)]
        public void Test()
        {
            Assert.True(true);
        }

        public void Dispose()
        {
            this.ServiceScope.Dispose();
        }

    }

}
