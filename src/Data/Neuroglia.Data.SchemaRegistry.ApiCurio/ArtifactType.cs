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

using System.Runtime.Serialization;

namespace Neuroglia.Data.SchemaRegistry
{

    /// <summary>
    /// Enumerates all supported artifact types
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]

    public enum ArtifactType
    {
        /// <summary>
        /// Indicates an Avro schema
        /// </summary>
        [EnumMember(Value = "Avro")]
        Avro,
        /// <summary>
        /// Indicates a PROTOBUF schema
        /// </summary>
        [EnumMember(Value = "PROTOBUF")]
        PROTOBUF,
        /// <summary>
        /// Indicates a JSON schema
        /// </summary>
        [EnumMember(Value = "JSON")]
        JSON,
        /// <summary>
        /// Indicates an OPENAPI schema
        /// </summary>
        [EnumMember(Value = "OPENAPI")]
        OPENAPI,
        /// <summary>
        /// Indicates an ASYNCAPI schema
        /// </summary>
        [EnumMember(Value = "ASYNCAPI")]
        ASYNCAPI,
        /// <summary>
        /// Indicates a GRAPHQL schema
        /// </summary>
        [EnumMember(Value = "GRAPHQL")]
        GRAPHQL,
        /// <summary>
        /// Indicates a KCONNECT schema
        /// </summary>
        [EnumMember(Value = "KCONNECT")]
        KCONNECT,
        /// <summary>
        /// Indicates a WSDL schema
        /// </summary>
        [EnumMember(Value = "WSDL")]
        WSDL,
        /// <summary>
        /// Indicates an XSD schema
        /// </summary>
        [EnumMember(Value = "XSD")]
        XSD,
        /// <summary>
        /// Indicates an XML schema
        /// </summary>
        [EnumMember(Value = "XML")]
        XML
    }

}
