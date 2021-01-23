    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
           var context = serviceScope.ServiceProvider.GetService<MyContext>();       
           context.Database.Migrate();
           context.EnsureSeedData();
     }
