    var deserializerSettings = new JsonSerializerSettings
    {
        //NullValueHandling = NullValueHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
        Converters = new List<JsonConverter> { new Converters.NoChangeTypeConverter() },
        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
    };
    var obj = JsonConvert.DeserializeObject<CustomerViewModel>(s, deserializerSettings);
