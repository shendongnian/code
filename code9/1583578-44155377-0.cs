    public class Item
    {
        public string id { get; set; }
        public string uploaded { get; set; }
        public string uploader { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string thumbnail { get; set; }
        public int duration { get; set; }
        public string path { get; set; }
    }
    
    public class RootObject
    {
        public string updated { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<Item> items { get; set; }
    }
