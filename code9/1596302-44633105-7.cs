    var dezerializerSettings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };
    var obj = JsonConvert.DeserializeObject<ErrorDetails>(json, dezerializerSettings);
