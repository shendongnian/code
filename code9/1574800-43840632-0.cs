    public class LogEntity : TableEntity
    {
        public LogEntity() { }
        
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public string RenderedMessage { get; set; }
    }
