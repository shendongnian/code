    //example method
    public void Seed(IApplicationBuilder app)
    {
         using(var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
         {
            var context = servicescope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
             if(!context.SomeTable.Any()){
                foreach(var item in SeedData.Items){
                  context.SomeTable.Add(item);
                }
                context.SaveChanges();
             }
            //for each table you need seeded data...
            //...
         }
    }
