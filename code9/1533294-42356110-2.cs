     public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
     {
          using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
          {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();
          }
          
          ...
