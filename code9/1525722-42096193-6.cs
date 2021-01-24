    var settings = new JsonSerializerSettings
    {
        ContractResolver =
            new OverrideContractResolver(
                new Dictionary<Type, IContractResolver> { { typeof(CaseToChange), new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() } },
                new Newtonsoft.Json.Serialization.DefaultContractResolver()),
    };
