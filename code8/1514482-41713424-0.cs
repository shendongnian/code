    public class MyItem
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string ParentId { get; set; }
        // to be filled
        public IList<MyItem> Children { get; set; }
    }
