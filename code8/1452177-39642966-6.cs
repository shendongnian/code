    public class ProductPartCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PartCategoryId { get; set; }
        public PartCategory PartCategory { get; set; }
    }
    
    public class Product 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public List<PartCategory> PartCategories{ get; set; } 
    }
     public class PartCategory
    {
        public int PartCategoryId { get; set; }
        public string Category { get; set; }
        public List<Product> Products { get; set; }
        //dont mind this propertie its for other stuff
        public List<Part> Parts { get; set; }
    }
