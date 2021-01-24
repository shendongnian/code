    public class Item
    {
        public string LocalTimestamp { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Processed { get; set; }
        public List<double> Position { get; set; }
    }
    
    public class AllItems
    {
        public List<Item> Items { get; set; }
        public bool HasMoreResults { get; set; }
    }
