       public void ConfigureServices(IServiceCollection services)
       {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<MyServiceClass>();
           
           services.AddScoped<Interface1>(provider=>
               var accessor = provider.GetService<IHttpContextAccessor>();
               return accessor.HttpContext.RequestServices.GetService<MyServiceClass>();
           );
           services.AddScoped<Interface2>(provider=>
               var accessor = provider.GetService<IHttpContextAccessor>();
               return accessor.HttpContext.RequestServices.GetService<MyServiceClass>();
           );
            services.AddMvc();
        }
