    var query = db.Products.Include(x => x.Category);
    
    if(catId != null && catId != 0)
    {
        //Add a where clause
        query = query.Where(x => x.CategoryId == catId);
    }
    productVM = query
        .ToList()
        .Select(x => new ProductVM(x));
