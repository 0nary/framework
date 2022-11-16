﻿using DotNet.Testcontainers.Builders;
using System;

namespace Neuroglia.UnitTests.Containers
{

    public static class MongoDBContainerBuilder
    {

        static MongoDBContainer Container;

        public static MongoDBContainer Build()
        {
            if (Container != null)
                return Container;
            Container = new TestcontainersBuilder<MongoDBContainer>()
                .WithName($"mongo-{Guid.NewGuid().ToString("N")}")
                .WithImage("mongo:latest")
                .WithPortBinding(MongoDBContainer.PublicPort, true)
                .WithEnvironment("MONGO_INITDB_ROOT_USERNAME", MongoDBContainer.DefaultUsername)
                .WithEnvironment("MONGO_INITDB_ROOT_PASSWORD", MongoDBContainer.DefaultPassword)
                .WithWaitStrategy(Wait
                    .ForUnixContainer()
                    .UntilPortIsAvailable(MongoDBContainer.PublicPort))
                .Build();
            Container.StartAsync().GetAwaiter().GetResult();
            return Container;
        }

    }

}
