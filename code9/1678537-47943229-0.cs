    string json = @"
    [
        {
            ""AB"": 20
        },
    
        {
            ""CD"": 15
        },
    
        {
            ""EF"": 35
        }
    ]";
    JArray obj = JsonConvert.DeserializeObject<JArray>(json);
    var dict = obj.ToList()
        .SelectMany(x => x.ToList())
        .Cast<JProperty>()
        .ToDictionary(x => x.Name, x => x.Value);
