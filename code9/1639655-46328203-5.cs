    services.AddSingleton<IMyModel>(sp =>
    {
        using (var scope = sp.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetService<MyContext>();
            var lastItem = dbContext.Items.LastOrDefault();
            return new MyModel(lastItem);
        }
    });    
