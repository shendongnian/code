        public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            ...
        }
 
