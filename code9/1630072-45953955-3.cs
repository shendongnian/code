    public class Items
    {
        public List<List<SubItem>> items; //list with list with prop name 'items'
    }
    
    public class SubItem // Object in the list in list
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
