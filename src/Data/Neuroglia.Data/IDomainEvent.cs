﻿/*
 * Copyright © 2021 Neuroglia SPRL. All rights reserved.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;

namespace Neuroglia.Data
{

    /// <summary>
    /// Defines the fundamentals of a domain event, that is an event bounded to a specific domain context
    /// </summary>
    public interface IDomainEvent
    {

        /// <summary>
        /// Gets the type of the <see cref="IAggregateRoot"/> that has produced the <see cref="IDomainEvent"/>
        /// </summary>
        Type AggregateType { get; }

        /// <summary>
        /// Gets the id of the <see cref="IAggregateRoot"/> that has produced the <see cref="IDomainEvent"/>
        /// </summary>
        object AggregateId { get; }

        /// <summary>
        /// Gets the date and time the <see cref="IDomainEvent"/> has been created at
        /// </summary>
        DateTimeOffset CreatedAt { get; }

    }

    /// <summary>
    /// Defines the fundamentals of a domain event, that is an event bounded to a specific domain context
    /// </summary>
    /// <typeparam name="TAggregate">The type of <see cref="IAggregateRoot"/> that has produced the <see cref="IDomainEvent"/></typeparam>
    public interface IDomainEvent<TAggregate>
        : IDomainEvent
        where TAggregate : IAggregateRoot
    {


    }

    /// <summary>
    /// Defines the fundamentals of a domain event, that is an event bounded to a specific domain context
    /// </summary>
    /// <typeparam name="TAggregate">The type of <see cref="IAggregateRoot"/> that has produced the <see cref="IDomainEvent"/></typeparam>
    /// <typeparam name="TKey">The type of key used to uniquely identify the <see cref="IAggregateRoot"/> that has produced the <see cref="IDomainEvent"/></typeparam>
    public interface IDomainEvent<TAggregate, TKey>
        : IDomainEvent<TAggregate>
        where TAggregate : IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
    {

        /// <summary>
        /// Gets the key of the <see cref="IAggregateRoot"/> that has produced the <see cref="IDomainEvent"/>
        /// </summary>
        new TKey AggregateId { get; }

    }

}
