    public class TestEntityClass
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        public int DocumentType { get; set; }
        [JsonProperty(PropertyName = "pId")]
        public string PartitionId { get; set; }
        [JsonProperty(PropertyName = "stringProperty")]
        public string StringProperty { get; set; }
        [JsonProperty(PropertyName = "numberProperty")]
        public int NumberProperty { get; set; }
    }
