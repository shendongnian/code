    public void ConfigureServices(IServiceCollection services)
        { 
            //other services
            services.Configure<AppSettings> Configuration.GetSection("AppSettings"));
            //other services
        }
