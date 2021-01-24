    IDictionary<string, object> dict = new Dictionary<string, object>()
    {
        { "type", "19" },
        { "id" ,"4433"}
    };
    
    var json = JsonConvert.SerializeObject(dict, new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented
    });
