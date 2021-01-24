    [JsonConverter(typeof(JsonPathConverter))]
    public class FacebookFeed
    {
        public FacebookFeed()
        {
            Posts = new List<FacebookFeedPost>();
        }
        [JsonPath("name")]
        public string Name { get; set; }
        [JsonPath("fan_count")]
        public int Likes { get; set; }
        [JsonPath("feed.data")]
        public List<FacebookFeedPost> Posts { get; set; }
    }
    [JsonConverter(typeof(JsonPathConverter))]
    public class FacebookFeedPost
    {
        [JsonPath("id")]
        public string Id { get; set; }
        [JsonPath("message")]
        public string Message { get; set; }
        [JsonPath("created_time")]
        public DateTime Date { get; set; }
        [JsonPath("comments.summary.total_count")]
        public int Comments { get; set; }
    }
