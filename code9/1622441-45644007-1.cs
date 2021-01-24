    var serializerSettings = new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
        Converters = new List<JsonConverter> { new StringEnumConverter() },
        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
    };
