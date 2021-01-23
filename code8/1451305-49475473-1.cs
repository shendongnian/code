    Settings = new JsonSerializerSettings
    {
        ContractResolver = new CompositeContractResolver
        {
            new InterfaceContractResolver<ISomething>(),
            new DefaultContractResolver()
        }
    }
