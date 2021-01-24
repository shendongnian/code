       public Startup(IHostingEnvironment env)
       {
            Mapper.Initialize(c =>
            {
                c.AddProfile<AutoMapperProfileConfiguration>();
            });
       }
       public void ConfigureServices(IServiceCollection services)
       {
            services.AddSingleton(s => Mapper.Instance);
       }
