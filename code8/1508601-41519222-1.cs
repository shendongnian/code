    public class Feed
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("pic_large")]
        public string PicLarge { get; set; }
    }
    public class Result
    {
        [JsonProperty("data")]
        public IList<Feed> Feeds { get; set; }
    }
