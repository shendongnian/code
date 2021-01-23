    public void Configure(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            using (var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
            {
                if (dbContext.Database.EnsureCreated())
                {
                    // Seed your database if necessary
                }
            }
        }
    }
