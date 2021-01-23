    public class Message
    {
        public int StoryId { get; set; }
        public string StoryDesc { get; set; }
    }
    
    public class Requirments
    {
        public string EventMessageUId { get; set; }
        public List<Message> Message { get; set; }
        public string ProjectId { get; set; }
    }
