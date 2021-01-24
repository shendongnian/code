    .AddJsonOptions(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy
            {
                ProcessDictionaryKeys = true
            }
        };
    });
