    public class MyContext : DbContext {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        { }
    
        public DbSet<Employee> Employees { get; set; }
    }
