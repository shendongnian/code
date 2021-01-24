    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class FooBar
    {
        public string CamelCaseProperty { get; set; }
        [JsonProperty("fOO")]
        public string Foo { get; set; }
        [JsonProperty("BAR")]
        public string Bar { get; set; }
    }
