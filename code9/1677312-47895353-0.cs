    public class ProductCategory
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public int SortOrder { get; set; }
        public List<ProductInCategory> ProductInCategory { get; set; }
    }
    
    public class ProductInCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SortOrder { get; set; }
        public int ProductCategoryId { get; set; }
    }
