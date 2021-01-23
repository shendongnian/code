    var products = db.Products.Include(x => x.Category).ToArray()
      
    if (catId == null || catId == 0)
    {
        productVM = products.Select(x => new ProductVM(x)).ToList();
    }
    else
    {
        productVM = products.Where(x => x.CategoryId == catId)
                            .Select(x => new ProductVM(x)).ToList();
    }
