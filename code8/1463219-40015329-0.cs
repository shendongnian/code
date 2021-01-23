    public class Value
    {
        [JsonProperty("@odata.etag")]
        public string etag { get; set; }
        public string accountnumber { get; set; }
        public string accountid { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("@odata.context")]
        public string context { get; set; }
        public List<Value> value { get; set; }
    }
