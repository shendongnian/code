    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext
    {
        public Context() : base("MyContext")
        {
        }
        public DbSet<Foo> foo;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Foo>();
        }
    }
