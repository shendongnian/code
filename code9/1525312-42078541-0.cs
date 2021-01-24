    public class SearchShim
    {
        [JsonProperty("header", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public SearchHeader AllUrls { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("can", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Can { get; set; }
    }
