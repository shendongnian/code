    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public List<Parent> Children { get; set; }
    }
