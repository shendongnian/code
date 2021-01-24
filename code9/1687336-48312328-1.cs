    public class RecMessage
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<MessageContent> Data { get; set; }
    }
    public class MessageContent
    {
        public string Message { get; set; }
    }
    
