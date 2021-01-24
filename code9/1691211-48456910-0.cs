    public void ConfigureServices(IServiceCollection services)  
    {
        services.AddMvc()
            .AddSessionStateTempDataProvider();			        <=== For asp.net core 2
    
        services.AddDistributedMemoryCache();			        <===
        services.AddSession(options =>				            <===
        {								                        <===
            options.IdleTimeout = TimeSpan.FromMinutes(30);		<===
            options.CookieName = ".MyApplication";			    <===
        });								                        <===
    }
