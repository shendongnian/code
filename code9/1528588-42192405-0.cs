    var providersObject = new {
     providers = providers
    };
    
    string providersJsonString = JsonConvert.SerializeObject(providersObject);
    JObject providersJson = JObject.Parse(providersJsonString);
    IList < string > messages;
    bool valid = providersJson.IsValid(schema, out messages);
    return valid;
