    // setup the HTTP request pipeline to check and migrate.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {           
        try
        {
            using (var migrationSvcScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
             migrationSvcScope.ServiceProvider.GetService<EFMigrationsMyDBContext>().Database.Migrate();
                // you can also add the data here... let me know if you need I will post it
            }
        }   
        ... // Rest of the startup stuff
    }
