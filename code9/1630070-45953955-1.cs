    public class Items
    {
        public List<Item> items; //list with prop name 'items'
    }
    public class Item : List<SubItem> // list in list like json notation
    {
    }
    
    public class SubItem // Object in the list in list
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
