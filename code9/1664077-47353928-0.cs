    public class Image
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
    public class Template
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "image")]
        public Image Image { get; set; }
        [JsonProperty(PropertyName = "target")]
        public string Target { get; set; }
    }
