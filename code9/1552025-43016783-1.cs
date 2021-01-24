    class MyContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Link> Links { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(p => p.Link)
                .WithOne(i => i.Item)
                .HasForeignKey<Item>(b => b.LinkId);
            modelBuilder.Entity<News>()
                .HasOne(p => p.Link)
                .WithOne(i => i.News)
                .HasForeignKey<News>(b => b.LinkId);
        }
    }
