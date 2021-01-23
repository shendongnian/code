	public class Feature
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Code")]
        public string Code { get; set; }
        [JsonProperty("ProductId")]
        public int ProductId { get; set; }
        [JsonProperty("Selected")]
        public object Selected { get; set; }
    }
    public class YourApp
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("ApplicationId")]
        public string ApplicationId { get; set; }
        [JsonProperty("Features")]
        public IList<Feature> Features { get; set; }
    }
