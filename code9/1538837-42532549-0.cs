      public class ProductEntityConfiguration : EntityConfiguration<Product> 
      {
          public ProductEntityConfiguration() 
          {
             Map(m => 
             { 
                m.Properties(t => new { t.ProductId, t.Status}); 
                m.ToTable("Product"); 
             }) 
             .Map(m => 
             { 
                m.Properties(t => new { t.ProductId, t.Name}); 
                m.ToTable("ProductNames"); 
             });
          }
      }
