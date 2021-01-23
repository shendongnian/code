    public class RootObject
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        [JsonProperty(NamingStrategyType = typeof(DefaultNamingStrategy))]
        [JsonConverter(typeof(AlternateContractResolverConverter), typeof(DefaultContractResolver))]
        public SomeDocument SomeDocument { get; set; }
    }
    public class SomeDocument
    {
        public string MyFirstProperty { get; set; }
        public string mysecondPROPERTY { get; set; }
        public AnotherRandomSubdoc another_random_subdoc { get; set; }
    }
    public class AnotherRandomSubdoc
    {
        public string evenmoredata { get; set; }
        public DateTime DateCreated { get; set; }
    }
