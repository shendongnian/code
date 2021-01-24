    [JsonConverter(typeof(DynamicPropertyNameConverter))]
    class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyNameByType("Vehicle", typeof(Vehicle))]
        [JsonPropertyNameByType("Profile", typeof(Profile))]
        public object Item { get; set; }
    }
