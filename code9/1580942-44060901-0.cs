    public class SubCategory
    {
        public int Id { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string Description { get; set; }
    
        public virtual Category Category { get; set; }
    }
