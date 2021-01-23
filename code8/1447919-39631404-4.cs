    using System;
    using Microsoft.EntityFrameworkCore;
    
    namespace AdventureWorksAPI.Models
    {
        public static class ProductMap
        {
            public static ModelBuilder MapProduct(this ModelBuilder modelBuilder, String schema)
            {
                var entity = modelBuilder.Entity<Product>();
    
                entity.ToTable("Product", schema);
    
                entity.HasKey(p => new { p.ProductID });
    
                entity.Property(p => p.ProductID).UseSqlServerIdentityColumn();
    
                return modelBuilder;
            }
        }
    }
