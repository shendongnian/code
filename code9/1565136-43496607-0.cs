    public class TestObject
    {
        [JsonProperty(Required = Required.Always)]
        public int Id { get; }
        public string Name { get; }
        [JsonProperty(Required = Required.AllowNull)]
        public List<string> List { get; }
    }
