    public class Light
    {
        public string LightName { get; set; }
        [JsonProperty("state")]
        public State LightState { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("modelid")]
        public string ModelId { get; set; }
        [JsonProperty("manufacturername")]
        public string Manufacturer { get; set; }
        [JsonProperty("uniqueid")]
        public string UniqueId { get; set; }
        [JsonProperty("swversion")]
        public string SwVersion { get; set; }
    }
