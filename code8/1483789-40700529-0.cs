    builder.Entity<Product>()
        .Property(p => p.ProductTypeId)
        .IsRequired()
        .WillCascadeOnDelete(false);
    builder.Entity<Product>()
        .Property(p => p.ProductCategoryId)
        .IsRequired()
        .WillCascadeOnDelete(false);
