    JsonSerializerSettings DeserializerSettings = new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore,
        ObjectCreationHandling = ObjectCreationHandling.Auto,
        ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        ContractResolver = new JsonContractResolver(),
        Converters = new List<JsonConverter>(new JsonConverter[]
        {
            new ListJsonConverter(),
            new InterfaceProxyConverter(GreenPipes.Internals.Extensions.TypeCache.ImplementationBuilder),
            new IsoDateTimeConverter {DateTimeStyles = System.Globalization.DateTimeStyles.RoundtripKind},
        })
    };
    
    var _deserializer = JsonSerializer.Create(DeserializerSettings);
