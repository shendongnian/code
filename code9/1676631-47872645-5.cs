    var settings = new JsonSerializerSettings
    {
        ContractResolver = new FormattedPropertyContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy(),
        },
    };
    var json = JsonConvert.SerializeObject(root, Formatting.Indented, settings);
