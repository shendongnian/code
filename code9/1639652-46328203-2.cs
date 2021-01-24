    services.AddSingleton<IMyModel>(s =>
    {
        using (var scope = s.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetService<MyContext>();
            var lastItem = dbContext.Items.LastOrDefault();
            return new MyModel(lastItem);
        }
    });    
