    public class Product
    {
      // ...
    }
    
    public class MyDbContext : DbContext
    {
      // ...
    
      public IDbSet<Product> Products { get; set; }
    }
