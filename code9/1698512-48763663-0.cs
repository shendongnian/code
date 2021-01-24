    private readonly string connectionString = null;
    
    public SamuraiContext(DbContextOptions<SamuraiContext> options)
            : base(options)
    {
    }
    
    public SamuraiContext(string connectionString) 
    {
      this.connectionString = connectionString; 
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(this.connectionString != null)
            optionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(this.connectionString);
    }
