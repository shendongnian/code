    builder.Entity<Product>()
        .Property(p => p.ProductTypeId)
        .IsRequired().WithOne()
        .OnDelete(DeleteBehavior.Restrict);
    builder.Entity<Product>()
        .Property(p => p.ProductCategoryId)
        .IsRequired().WithOne()
        .OnDelete(DeleteBehavior.Restrict);
