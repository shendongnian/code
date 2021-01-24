    public void ConfigureServices(IServiceCollection services)
        {
            ....
            services.AddSession(options => { 
                    options.IdleTimeout = TimeSpan.FromMinutes(30); 
                    options.CookieName = ".MyApplication";
                });
        }
