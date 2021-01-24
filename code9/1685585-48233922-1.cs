    public static void Initialize(MyContext context, IConfiguration config)
    {
        ...
    }
    IServiceProvider isp = iss.ServiceProvider;
    try
    { 
        var configuration = isp.GetRequiredService<IConfiguration>();
        var context = isp.GetRequiredService<MyContext>();
        SeedData.Initialize(context, configuration);
    }
