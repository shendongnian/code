    public class ShoppingDbContext: DbContext
        {
            public DbSet< Product> Products { get; set; }
            public DbSet< PartCategory> PartCategories{ get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<ProductPartCategory>()
                    .HasKey(t => new { t.ProductId, t.PartCategoryId });
    
                modelBuilder.Entity<ProductPartCategory>()
                    .HasOne(pt => pt.Product)
                    .WithMany(p => p.PartCategories)
                    .HasForeignKey(pt => pt.ProductId);
    
                modelBuilder.Entity<ProductPartCategory>()
                    .HasOne(pt => pt.PartCategory)
                    .WithMany(t => t.Products)
                    .HasForeignKey(pt => pt.PartCategoryId);
            }
        }
