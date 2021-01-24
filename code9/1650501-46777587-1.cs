    public void ConfigureServices(IServiceCollection services)
        {
            if (Configuration["Environment"] != "IntegrationTest")
            {
                services.AddTransient<IExternalService, ExternalService>();
            }
            
            services.AddMvc();
            
            // ...
        }
