    namespace Test
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.Data.Entity;
        using System.Linq;
        internal class Program
        {
            private static void Main(string[] args)
            {
                List<ProductVM> productVM;
                //It doesn't matter if you use a using block or not
                using (Db db = new Db())
                {
                    db.Database.Log = Console.WriteLine;//To see the generated SQL
                    productVM = db.Products
                                  .Include(p => p.Category)
                                  .Select(p => new ProductVM
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      Description = p.Description,
                                      Price = p.Price,
                                      CategoryId = p.CategoryId,
                                      CategoryName = p.Category.Name,
                                      ImageName = p.ImageName,
                                  }).ToList();
                }
                Console.ReadKey();
            }
        }
        public class Db : DbContext
        {
            public DbSet<ProductDTO> Products { get; set; }
            public DbSet<CategoryDTO> Categories { get; set; }
        }
        public class ProductDTO
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Slug { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public string ImageName { get; set; }
            [ForeignKey("CategoryId")]
            public virtual CategoryDTO Category { get; set; }
        }
        public class CategoryDTO
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class ProductVM
        {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            public decimal Price { get; set; }
            public int? CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string ImageName { get; set; }
        }
    }
