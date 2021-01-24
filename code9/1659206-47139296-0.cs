    public class Response
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public class Data : Dictionary<string, Item> { }
    public class Item
    {
        [JsonProperty("details")]
        public Detail[] Details { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
    }
    public class Detail
    {
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
