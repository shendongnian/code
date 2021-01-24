    public class Items : List<Item>
    {
    }
    public class Item : List<SubItem>
    {
    }
    
    public class SubItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
