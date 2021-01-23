    public  class MyContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Blog>()
                    .Property(b => b.Url)
                    .HasMaxLength(500);
            }
        }
