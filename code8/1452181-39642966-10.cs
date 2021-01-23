     public class Product 
      {
    
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public List<ProductPartCategory> ProductPartCategories { get; set; } 
    
      }
    
     public class PartCategory
       {
         public int PartCategoryId { get; set; }
         public string Category { get; set; }
         public List<ProductPartCategory> ProductPartCategories { get; set; } 
       }
        
      public class ProductPartCategory
        {
          public int ProductId { get; set; }
          public Product Product { get; set; }
        
          public int PartCategoryId { get; set; }
          public PartCategory PartCategory { get; set; }
       }
