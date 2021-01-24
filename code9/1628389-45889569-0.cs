    public class Category
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    
        public Category ParentCategory { get; set; }
        public List<Category> ChildCategories { get; set; }
    }
