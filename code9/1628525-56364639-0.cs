    private readonly ILoggerFactory loggerFactory;  
    public MyDataContext(DbContextOptions<MyDataContext> options, ILoggerFactory loggerFactory)
            : base(options)
    {
        this.loggerFactory = loggerFactory;
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
    {
        // Allow null if you are using an IDesignTimeDbContextFactory
        if (loggerFactory != null)
        { 
            if (Debugger.IsAttached)
            {
                // Probably shouldn't log sql statements in production
                optionsBuilder.UseLoggerFactory(this.loggerFactory); 
            }
        }
    } 
