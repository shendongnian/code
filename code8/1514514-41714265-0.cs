    class Program
    {
        static void Main()
        {
            using (var context = new ProductContext())
            {
                var cat1 = new Cat {CatId = Guid.NewGuid(), CatName = "MyCat1"};
                var cat2 = new Cat {CatId = Guid.NewGuid(), CatName = "MyCat2"};
                context.Cats.Add(cat1);
                context.Cats.Add(cat2);
                context.Products.Add(new Product {Cat = cat1});
                context.Products.Add(new Product {Cat = cat2});
                context.SaveChanges();
            }
        }
    }
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cat> Cats { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasOptional(s => s.Cat).WithMany().HasForeignKey(f => f.FkCatId);
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public Guid? FkCatId { get; set; }
        public virtual Cat Cat { get; set; }
    }
    public class Cat
    {
        [Key]
        public Guid CatId { get; set; }
        public string CatName { get; set; }
    }
