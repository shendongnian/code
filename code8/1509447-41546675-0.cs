    public class CategoryView
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }        
        // other properties ...
        public CategoryView ParentCategory { get; set; }
        public List<CategoryView> SubCategories { get; set; }
        public int ProductCount { get; set; }
        public CategoryView()
        {            
            SubCategories = new List<CategoryView>();
        }
    }
