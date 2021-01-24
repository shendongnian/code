    public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory = 
    new LoggerFactory(new[] { 
    new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() 
    });
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_myLoggerFactory);
    }
