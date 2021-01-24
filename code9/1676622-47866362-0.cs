    public class Textlist
    {
        public string text { get; set; }
    }
    
    public class Item
    {
        public string type { get; set; }
        public List<Textlist> textlist { get; set; }
    }
    
    public class RootObject
    {
        public string messageID { get; set; }
        public Item item { get; set; }
    }
