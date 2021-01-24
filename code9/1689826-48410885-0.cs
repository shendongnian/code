    public class Group 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId ")]
        public virtual Category Category { get; set; }    
    }
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Group> Groups { get; set; }
    }
