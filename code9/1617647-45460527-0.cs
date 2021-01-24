    class TreeModelJson
    {
        [JsonProperty("ChangeFlowsFromParent")]
        public string ChangeFlowsFromParent { get; set; }
        [JsonProperty("ChangeFlowsToParent")]
        public string ChangeFlowsToParent { get; set; }
        [JsonProperty("StreamType")]
        public string StreamType { get; set; }
        [JsonProperty("streamName")]
        public string StreamName { get; set; }
        [JsonProperty("Parent")]
        public string Parent { get; set; }
        [JsonProperty("Compliance")]
        public string Compliance { get; set; }
        [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<TreeModelJson> Children { get; set; }
    }
