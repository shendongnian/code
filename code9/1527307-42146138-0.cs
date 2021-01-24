    public class Item
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Item> SubItems { get; set; }
        public bool IsLastItem { get { return SubItems.Count == 0; } }
    }
