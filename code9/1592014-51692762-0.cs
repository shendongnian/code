            public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NopaDbContext>(
                            options => options
                            .UseLazyLoadingProxies()
                            .UseSqlServer(Configuration.GetConnectionString("NopaDbContext")),ServiceLifetime.Scoped);}
