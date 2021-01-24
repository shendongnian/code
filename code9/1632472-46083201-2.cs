    var settings = new JsonSerializerSettings
    {
        ContractResolver = new ConfigurableContractResolver
        {
            // Here I am using CamelCaseNamingStrategy as is shown in your JSON.
            // If you don't want camel case, leave NamingStrategy null.
            NamingStrategy = new CamelCaseNamingStrategy(),
        }.Configure((s, e) => { e.Contract.AddDateProperties(); }),
    };
    var json = JsonConvert.SerializeObject(example, Formatting.Indented, settings);
