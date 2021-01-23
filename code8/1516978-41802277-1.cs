         public class SampleDbContext : DbContext
        {
            public SampleDbContext()
                : base("name=SampleDBConnection")
            {
                this.Configuration.LazyLoadingEnabled = true;
                this.Configuration.ProxyCreationEnabled = true;
            }
          
            public DbSet<Product> Products { get; set; }
            public DbSet<OrderedItem> OrderedItems { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
              
                modelBuilder.Entity<Product>().HasMany(c => c.OrderedItems);
            }
        }
