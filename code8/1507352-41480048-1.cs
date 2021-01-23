    public class Message
    {
        [JsonProperty("StoryId")]
        public int StoryId { get; set; }
        [JsonProperty("StoryDesc")]
        public string StoryDesc { get; set; }
    }
    public class MyMessages
    {
        [JsonProperty("Message")]
        public Message Message { get; set; }
    }
	
