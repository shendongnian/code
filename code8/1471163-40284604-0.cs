    public class JsonContainer
    {
        [JsonProperty("suggestions")]
        public List<JsonData> Suggestions { get;set; }
    }
    public class JsonData
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        
        [JsonProperty("data")]
        public string Data { get; set; }
    }
    // ...
    var results = new SortedList<string, string>();
    results.Add("BOBB", "Bob Brattwurst");
    results.Add("DANG", "Dan Germany");
    results.Add("KON", "Konrad Plith");
    var container = new JsonDataContainer();
    container.Suggestions = results.Select(r => new JsonData
    {
        Value = r.Key,
        Data = r.Value
    }).ToList();
    
    var json = JsonConvert.SerializeObject(container);
