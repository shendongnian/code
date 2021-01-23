    public class Document
    {
        public List<string> keyPhrases { get; set; }
        public string id { get; set; }
    }
    
    public class RootObject
    {
        public List<Document> documents { get; set; }
        public List<object> errors { get; set; }
    }
