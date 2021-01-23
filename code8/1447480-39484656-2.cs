    public class Result
    {
        public string count { get; set; }
    }
    
    public class Content
    {
        public string message_id { get; set; }
        public string originator { get; set; }
        public string message { get; set; }
        public string timestamp { get; set; }
    }    
    
    public class RootObject
    {
        public Result result { get; set; }
        public Content content_1 { get; set; }
        public Content content_2 { get; set; }
        public Content content_3 { get; set; }
    }
