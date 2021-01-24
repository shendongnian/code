    public class TagLink {
        [Key]
        public int Id { get; set; }
    
        public int PageId { get; set; }
    
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
    public class Tag {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TagLink> TagLinks { get; set; }
    }
