    var propertiesContractResolver = new PropertiesContractResolver();
    propertiesContractResolver.ExcludeProperties.Add("BClass.Id");
    var serializerSettings = new JsonSerializerSettings();
    serializerSettings.ContractResolver = propertiesContractResolver;
    JsonConvert.SerializeObject(a, serializerSettings);
