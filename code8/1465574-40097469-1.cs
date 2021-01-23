    public class MyItem
    {
        public Item item { get; set; }
    }
    public class Item
    {
        public string icon { get; set; }
        public string icon_large { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public string typeIcon { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Current current { get; set; }
        public Today today { get; set; }
        public string premium { get; set; }
    }
    public class Current
    {
        public string trend { get; set; }
        public int price { get; set; }
    }
    public class Today
    {
        public string trend { get; set; }
        public string price { get; set; }
    }
