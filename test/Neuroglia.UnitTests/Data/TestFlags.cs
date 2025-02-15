﻿using System;
using System.Runtime.Serialization;

namespace Neuroglia.UnitTests.Data
{
    [Flags]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.StringEnumConverterFactory))]
    public enum TestFlags
    {
        [EnumMember(Value = "VALUE1")]
        Value1,
        [EnumMember(Value = "VALUE2")]
        Value2,
        [EnumMember(Value = "VALUE3")]
        Value3
    }

}
