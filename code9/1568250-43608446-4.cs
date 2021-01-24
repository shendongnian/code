       public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            var connectionString = Configuration.GetConnectionString("SurveyEntities");
            services.AddScoped<SurveyEntities>(_ => new SurveyEntities(connectionString));
            services.AddScoped<IPropertiesRepo, PropertiesRepo>();
    
        }
