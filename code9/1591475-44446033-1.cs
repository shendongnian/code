    public class Container
    {
        [JsonProperty("pictures")]
        public List<Picture> Pictures { get; set; }
    }
    public class Picture
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
