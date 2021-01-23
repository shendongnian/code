    public class RootObject
    {
        [JsonExtensionData]
        public Dictionary<string, object> Items { get; set; }
        [JsonProperty("random")]
        public string Random { get; set; }
        [JsonProperty("other")]
        public string Other { get; set; }
    }
