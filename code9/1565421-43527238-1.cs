    using( var dbContext = new MyContext() )
    {
        dbContext.Configuration.ProxyCreationEnabled = true;
        dbContext.Configuration.LazyLoadingEnabled = true;
        // Note: You can modify or derive from `MyContext` so that this is
        //       done automatically whenever a new `MyContext` is instantiated
        var backpack = dbContext.Backpacks.Where(b=>b.Name!="").FirstOrDefault();
        // This should work
        var firstBook = backpack.Books.FirstOrDefault();
    }
    // This will probably not, because the context was already disposed
    var firstDrink = backpack.Drinks.FirstOrDefault();
