    public class MyappDbContext : DbContext
    {
        private readonly ILogger<MyappDbContext> _logger;
    
        public MyappDbContext(DbContextOptions<MyappDbContext> options,
            ILogger<MyappDbContext> logger)
            : base(options)
        {
            _logger = logger;
        }
    }
