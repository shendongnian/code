    public class Query
    {
        public Normalized[] normalized { get; set; }
        public Dictionary<string, Page> pages { get; set; }
    }
    
    public class Page
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public string extract { get; set; }
    }
