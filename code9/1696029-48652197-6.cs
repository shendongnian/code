    public class FooBar
    {
        public string CamelCaseProperty { get; set; }
        [JsonProperty("fOO")]
        public string Foo { get; set; }
        [JsonProperty("BAR", NamingStrategyType = typeof(DefaultNamingStrategy))]
        public string Bar { get; set; }
    }
