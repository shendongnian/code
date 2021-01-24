    public class Root
    {
        [JsonProperty("threaded_extended")]
        public Dictionary<int, List<Post>> ThreadedExtended { get; set; } 
    }
    public class Post
    {        
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("sender_id")]
        public int SenderId { get; set; }
        // etc
    }
