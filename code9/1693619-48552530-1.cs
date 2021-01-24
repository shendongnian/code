    public class JsonClass
    {
        public string ID { get; set; }
        public Chat[] Chat { get; set; }
    }
    
    public class Chat
    {
        public string ID { get; set; }
        public string Message { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
    }
