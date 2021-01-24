    public class Command
    {
        [JsonRequired]
        public string Name { get; set; }
        [DefaultValue("Json!")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string Text { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
    }
