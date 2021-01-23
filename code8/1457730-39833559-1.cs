       public void ConfigureServices(IServiceCollection services)
       {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddScoped<MyServiceClass>();
           
           services.AddScoped<Interface1>(provider=>
                return provider.GetService<MyServiceClass>();
           );
           services.AddScoped<Interface2>(provider=>
                return provider.GetService<MyServiceClass>();
           );
            services.AddMvc();
        }
