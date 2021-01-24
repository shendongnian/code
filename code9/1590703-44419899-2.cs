    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<ProductCategory>()
           .HasKey(c => new { c.CategoryId, c.ProductId });
    
       modelBuilder.Entity<Product>()
           .HasMany(c => c.ProductCategories)
           .WithRequired()
           .HasForeignKey(c => c.ProductId);
    
       modelBuilder.Entity<Category>()
           .HasMany(c => c.ProductCategories)
           .WithRequired()
           .HasForeignKey(c => c.CategoryId);  
    }
