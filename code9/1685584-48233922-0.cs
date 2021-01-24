    public static void Initialize(MyContext context, IConfiguration config)
    {
        ...
    }
    IServiceProvider isp = iss.ServiceProvider;
    try
    { 
        var configuration = isp.GetRequiredService<IConfiguration>();
        SeedData.Initialize(isp, configuration);
    }
