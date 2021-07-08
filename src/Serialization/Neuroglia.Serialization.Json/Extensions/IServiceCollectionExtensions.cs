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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Text.Json;

namespace Neuroglia.Serialization
{

    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>s
    /// </summary>
    public static class IServiceCollectionExtensions
    {

        /// <summary>
        /// Adds and configures a <see cref="JsonSerializer"/> service
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure</param>
        /// <param name="configurationAction">The <see cref="Action{T}"/> used to configure the <see cref="JsonSerializerOptions"/> used by the <see cref="JsonSerializer"/></param>
        /// <returns>The configured <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddJsonSerializer(this IServiceCollection services, Action<JsonSerializerOptions> configurationAction)
        {
            services.Configure(configurationAction);
            services.TryAddSingleton<JsonSerializer>();
            services.AddSingleton<ISerializer>(provider => provider.GetRequiredService<JsonSerializer>());
            services.AddSingleton<ITextSerializer>(provider => provider.GetRequiredService<JsonSerializer>());
            services.AddSingleton<IJsonSerializer>(provider => provider.GetRequiredService<JsonSerializer>());
            return services;
        }

        /// <summary>
        /// Adds and configures a <see cref="JsonSerializer"/> service
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure</param>
        /// <returns>The configured <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddJsonSerializer(this IServiceCollection services)
        {
            services.AddJsonSerializer(settings => { });
            return services;
        }

    }

}
