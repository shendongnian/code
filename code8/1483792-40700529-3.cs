    builder.Entity<Product>()
        .Property(p => p.ProductTypeId)
        .WithOne()
        .OnDelete(DeleteBehavior.Restrict);
    builder.Entity<Product>()
        .Property(p => p.ProductCategoryId)
        .WithOne()
        .OnDelete(DeleteBehavior.Restrict);
