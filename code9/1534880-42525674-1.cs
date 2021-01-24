    class Context : DbContext
    {
        public Context(DbConnection connection)
            : base(connection, false)
        { }
        public DbSet<ClassA> As { get; set; }
        public DbSet<ClassB> Bs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassB>().HasOptional(c => c.ClassA).WithOptionalDependent(c => c.ClassB);
        }
    }
