    serializer = new JsonSerializer
    {
        TypeNameHandling = TypeNameHandling.Auto,
        ObjectCreationHandling = ObjectCreationHandling.Replace,
        DefaultValueHandling = DefaultValueHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore,
        ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        ContractResolver = new DefaultContractResolver()
    };
