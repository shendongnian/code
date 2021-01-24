    [HttpGet]
    public IQueryable<Supplier> SuppliersWithProductCount()
    {
        var query = _repository.Suppliers.AsQueryable();
        // ...add server-side params to the query, if desired...
        // Get objects with the supplier and the count
        var list = query.Select(s => new { Supplier = s, Count = s.Products.Count }).ToList();
        // Set the count on the Supplier
        list.ForEach(o => o.Supplier.ProductCount = o.Count);
        // Extract the Suppliers
        var suppliers = list.Select(o => o.Supplier);
        return suppliers.AsQueryable();
    }
