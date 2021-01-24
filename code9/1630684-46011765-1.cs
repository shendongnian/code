    IEnumerable<string> properties = null;
    if (condition)
    {
        properties = new List<string> { "Base64Content" };
    }
    
    var settings = new JsonSerializerSettings()
    {
        ContractResolver = new CustomPropertiesContractResolver(properties)
    };
    var serializedStr = JsonConvert.SerializeObject(messages, settings);
