    public class ModelPageLocationList
    {
    	[JsonProperty("odatametadata")]
        public string odatametadata { get; set; }
    	[JsonProperty("value")]
        public List<Value> value { get; set; }
    }
    
    public class Value
    {
    	[JsonProperty("code")]
        public string Code { get; set; }
    	[JsonProperty("name")]
        public string Name { get; set; }
    	[JsonProperty("xTag")]
        public string XTag { get; set; }
    }
