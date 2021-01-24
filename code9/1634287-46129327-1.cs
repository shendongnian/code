    public class MenuItem
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public long ID { get; set; }
        public Menu Menu { get; set; }
        public string Name { get; set; }
        public string PictureUrls { get; set; }
        public float Price { get; set; }
        public string Reference { get; set; }
        public ICollection<MenuItemRelation> RelatedItems { get; set; }
        public ICollection<MenuItemRelation> RelatedTo { get; set; }
        public string Status { get; set; }
    }
