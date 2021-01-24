    var housesObject = new {
     houses = houses
    };
    
    string housesJsonString = JsonConvert.SerializeObject(housesObject);
    JObject housesJson = JObject.Parse(housesJsonString);
    IList < string > messages;
    bool valid = housesJson.IsValid(schema, out messages);
    return valid;
