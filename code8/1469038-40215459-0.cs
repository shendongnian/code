    private static object syncRoot = new object();
    private static IConfiguration configuration;
    public static IConfiguration Configuration
    {
        get
        {
            lock (syncRoot)
                return configuration;
        }
    }
    
    public Startup()
    {
        configuration = new ConfigurationBuilder().Build(); // add more fields
    }
