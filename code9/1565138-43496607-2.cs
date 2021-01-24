    public class TestObject
    {
        // Id has to be present in the JSON
        [JsonProperty(Required = Required.Always)]
        public int Id { get; }
        // Name is optinional
        [JsonProperty]
        public string Name { get; }
        // List has to be present in the JSON but may be null
        [JsonProperty(Required = Required.AllowNull)]
        public List<string> List { get; }
    }
