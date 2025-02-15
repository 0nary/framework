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
using Neuroglia;
using System.Collections.Concurrent;
using System.Linq;

namespace System.Text.Json.Serialization
{
    /// <summary>
    /// Represents the <see cref="JsonConverterFactory"/> used to create <see cref="StringEnumConverter{TEnum}"/>
    /// </summary>
    public class StringEnumConverterFactory
        : JsonConverterFactory
    {

        /// <summary>
        /// Gets a <see cref="ConcurrentDictionary{TKey, TValue}"/> containing the mappings of types to their respective <see cref="JsonConverter"/>
        /// </summary>
        private static readonly ConcurrentDictionary<Type, JsonConverter> Converters = new();

        /// <summary>
        /// Initializes a new <see cref="StringEnumConverterFactory"/>
        /// </summary>
        /// <param name="jsonSerializerOptions">The <see cref="System.Text.Json.JsonSerializerOptions"/> for writing enum values</param>
        public StringEnumConverterFactory(JsonSerializerOptions jsonSerializerOptions)
        {
            this.JsonSerializerOptions = jsonSerializerOptions;
        }

        /// <summary>
        /// Initializes a new <see cref="StringEnumConverterFactory"/>
        /// </summary>
        public StringEnumConverterFactory()
            : this(jsonSerializerOptions: null)
        {

        }

        /// <summary>
        /// Gets the <see cref="System.Text.Json.JsonSerializerOptions"/> for writing enum values
        /// </summary>
        protected JsonSerializerOptions JsonSerializerOptions { get; }

        /// <inheritdoc/>
		public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum || (typeToConvert.IsGenericType && typeToConvert.IsNullable() && typeToConvert.GetGenericArguments().First().IsEnum);
        }

        /// <inheritdoc/>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type enumType = typeToConvert;
            if (enumType.IsGenericType && enumType.IsNullable() && enumType.GetGenericArguments().First().IsEnum)
                enumType = enumType.GetGenericArguments().First();
            if (!Converters.TryGetValue(typeToConvert, out JsonConverter converter))
            {
                Type converterType = typeof(StringEnumConverter<>).MakeGenericType(typeToConvert);
                converter = (JsonConverter)Activator.CreateInstance(converterType, enumType, this.JsonSerializerOptions);
                Converters.TryAdd(typeToConvert, converter);
            }
            return converter;
        }

    }


}
