    class Statistics
    {
        [JsonProperty("entries")]
        public Dictionary<string, Entry> Entries { get; set; }
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("selfLink")]
        public string SelfLink { get; set; }
    }
    class Entry
    {
        [JsonProperty("value")]
        public long Value { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("nestedStats")]
        public Statistics NestedStats { get; set; }
    }
