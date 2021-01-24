    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace Ef6Test
    {
    
        public class Product
        {
            [Key]
            public int ProductId { get; set; }
    
            [Required]
            public int ProductTypeId { get; set; }
    
            [ForeignKey("ProductTypeId")]
            public virtual ProductType ProductType { get; set; }
        }
    
        public class ProductType
        {
            [Key]
            public int ProductTypeId { get; set; }
        }
    
    
        class Db : DbContext
        {
    
    
            public DbSet<Product> Products { get; set; }
            public DbSet<ProductType> ProductTypes { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
        
                Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
                
                using (var db = new Db())
                {
                    Product product = new Product();
                    product.ProductType = new ProductType();
                    db.Products.Add(product);
                    db.SaveChanges();  // works fine
                }
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
