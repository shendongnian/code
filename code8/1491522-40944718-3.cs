    public class Data
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class GCM
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("default")]
        public string Default { get; set; }
        [JsonProperty("GCM")]
        public GCM GCM { get; set; }
    }
