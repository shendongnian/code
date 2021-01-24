    class MyDbContext : DbContext
    {
        public DbSet<Table1> Table1s {get; set;}
        public DbSet<Table2> Table2s {get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table1>().ToTable("Table1s");
            modelBuilder.Entity<Table2>().ToTable("Table2s");
        }
    }
