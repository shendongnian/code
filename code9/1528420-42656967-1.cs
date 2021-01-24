    [HttpGet]
    public IQueryable<Object> SuppliersWithProductCount()
    {
        var query = ContextProvider.Context.Suppliers.AsQueryable();
        // ...add server-side params to the query, if desired...
        // Get objects with the supplier and the count
        return query.Select(s => new { Supplier = s, Count = s.Products.Count });
    }
