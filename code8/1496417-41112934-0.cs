    using (var dbContext = new MyContext())
    {
        var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
        var itemsToBeFiltered = objectContext.CreateQuery<Product>("sql here...", params);
    }
