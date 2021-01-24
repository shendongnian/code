    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<FrontPageProduct> InFrontPages { get; set; }
        public List<ProductInCategory> InCategories { get; set; }
    }
    
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
        [ForeignKey(nameof(ParentCategory))]
        public int? ParentId { get; set; }
        public ProductCategory ParentCategory { get; set; }
        public ICollection<ProductCategory> Children { get; set; } = new List<ProductCategory>();
        public List<ProductInCategory> ProductInCategory { get; set; }
    }
    
    public class FrontPageProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public int SortOrder { get; set; }
    [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    [ForeignKey("ProductCategoryId ")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
