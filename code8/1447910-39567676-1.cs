    class MyContext : DbContext
    {
        public string Schema { get; private set; }
        public MyContext(string schema) : base()
        {
            
        }
        // Your DbSets here
        DbSet<Emp> Emps { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emp>()
                .ToTable("Emps", Schema);
        }
    }
