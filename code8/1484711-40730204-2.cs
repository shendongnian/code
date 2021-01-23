    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options) { }
        public DbSet<SomeEntity> SomeEntities { get; set; }
        ...
