    class ShopContext: DbContext
            {
                public ShopContext() : base("myConnection")
                {
        
                }
        
                public DbSet<User> Users { get; set; }
                public DbSet<Product> Products { get; set; }
        
            }
