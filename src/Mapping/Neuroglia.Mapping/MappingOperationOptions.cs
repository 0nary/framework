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
using System.Collections.Generic;

namespace Neuroglia.Mapping
{

    /// <summary>
    /// Represents the default implementation of the <see cref="IMappingOperationOptions{TSource, TDestination}"/> interface
    /// </summary>
    public class MappingOperationOptions
        : IMappingOperationOptions
    {

        /// <summary>
        /// Initializes a new <see cref="MappingOperationOptions{TSource, TDestination}"/>
        /// </summary>
        public MappingOperationOptions()
        {
            this.Items = new Dictionary<string, string>();
        }

        /// <inheritdoc/>
        public IDictionary<string, string> Items { get; }

    }

    /// <summary>
    /// Represents the default implementation of the <see cref="IMappingOperationOptions{TSource, TDestination}"/> interface
    /// </summary>
    /// <typeparam name="TSource">The type to map from</typeparam>
    /// <typeparam name="TDestination">The type to map to</typeparam>
    public class MappingOperationOptions<TSource, TDestination>
        : MappingOperationOptions, IMappingOperationOptions<TSource, TDestination>
    {



    }

}
