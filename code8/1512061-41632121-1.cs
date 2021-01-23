    public class Item
    {
        public string Type { get; set; }
        public Guid Owner { get; set; }
        public string Description { get; set; }
        public IList<string> Tag { get; set; }
        ...
    }
