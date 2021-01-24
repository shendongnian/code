    class Root
    {
        [JsonProperty(PropertyName = "files")]
        public List<object> Files { get; set; } = new List<object>();
    }
    class UrlContainer
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "headers")]
        public Headers Headers { get; set; }
    }
    class Headers
    {
        public string Origin { get; set; }
        [JsonProperty(PropertyName = "CF-IPCountry")]
        public string CfIpCountry { get; set; }
        [JsonProperty(PropertyName = "CF-Device-Type")]
        public string CfDeviceType { get; set; }
    }
