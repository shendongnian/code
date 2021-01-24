    using (var readScope = Services.CreateScope())
    using (var writeScope = Services.CreateScope())
    {
       var entities = readScope.ServiceProvider.GetRequiredService<IReadService>().GetEntities();
       var writeService = writeScope.ServiceProvider.GetRequiredService<IWriteService>();
       foreach (Entity entity in entities)
       {
           writeService.DoSomething(entity);
       } 
    }
