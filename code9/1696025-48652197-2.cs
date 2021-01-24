    public class FooBar
    {
        public string CamelCaseProperty { get; set; }
        [JsonProperty("fOO", NamingStrategyType = typeof(DefaultNamingStrategy))]
        public string Foo { get; set; }
        [JsonProperty("BAR")]
        public string Bar { get; set; }
    }
