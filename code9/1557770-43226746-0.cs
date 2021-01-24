    public class Item
    {
        public bool buy { get; set; }
        public string issued { get; set; }
        public double price { get; set; }
        public int volume { get; set; }
        public int duration { get; set; }
        public int id { get; set; }
        public int minVolume { get; set; }
        public int volumeEntered { get; set; }
        public string range { get; set; }
        public int stationID { get; set; }
        public int type { get; set; }
    }
    
    public class Previous
    {
        public string href { get; set; }
    }
    
    public class Next
    {
        public string href { get; set; }
    }
    
    public class RootObject
    {
        public List<Item> items { get; set; }
        public int totalCount { get; set; }
        public Previous previous { get; set; }
        public Next next { get; set; }
        public int pageCount { get; set; }
    }
