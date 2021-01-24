    public class MyDbContext : DbContext
        {
            private readonly IConnectionService _connectionService;
    
            public MyDbContext(DbContextOptions<MyDbContext> options, IConnectionService connectionService) : base(options)
            {
                _connectionService = connectionService;
            }
    
            public DbSet<Customer> Customers { get; set; }
            
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var connectionString = _companyConnectionService.ConnectionString; //Custom logic to read from http request header certain value and switch connection string
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
