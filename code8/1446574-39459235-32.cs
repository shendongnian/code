    class DatabaseContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<User> Users { get; set; }
    
        public DatabaseContext() : base("Demo")
        {
        }
    }
