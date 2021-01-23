    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        // you can remove the attribute
        [ForeignKey(nameof(ParentId))]
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; } = new HashSet<Category>();
    }
    public class Thread
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        // you can remove the attribute
        [ForeignKey(nameof(Category))]
        public Category Category { get; set; }
    }
