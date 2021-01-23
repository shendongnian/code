    public class Requirements
    {
        public string EventMessageUId { get; set; }
        public int ProjectId { get; set; }
        public string CreatedByUser { get; set; }
        public string CreatedByApp { get; set; }        
        public string CreatedOn { get; set; }
        public Message message { get; set; }
    }
    public class Message
    {
        public string StoryID { get; set; }
        public string StoryDesc { get; set; }
    }
