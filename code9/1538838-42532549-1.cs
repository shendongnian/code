      public class ProductEntityConfiguration : EntityConfiguration<Product> 
      {
          public ProductEntityConfiguration() 
          {
             Map(m => 
             { 
                m.Property(t => t.ProductId).HasColumnName("MyIdChanged");
                m.Property(t => t.Status).HasColumnName("Status");                
                m.ToTable("Product")
             }) 
             .Map(m => 
             { 
                m.Property(t => t.ProductId).HasColumnName("MyProductIdChanged");
                m.Property(t => t.Name).HasColumnName("MyProductName");
                m.ToTable("ProductNames"); 
             });
          }
      }
