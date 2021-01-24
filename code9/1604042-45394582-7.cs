    var serializerSettings = new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
        Converters = new List<JsonConverter> { new ChangeTypeConverter() },
        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
    };
    var s = JsonConvert.SerializeObject(customerViewModel, serializerSettings);
