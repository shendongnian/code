    public class Root
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        [JsonProperty("value")]
        public List<Value> Value { get; set; }
    }
    public class Value
    {
        [JsonProperty("Id")]
        public long Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
