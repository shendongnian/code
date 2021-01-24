    //get your product
    var product = context.Products.Include("Categories")
            .First();
    
    // remove categories for product
    product.Categories.Clear();
    //save changes
    context.SaveChanges();
    
    /* if that doesn't work try this alternate way to remove categories for product*/
    var categories = product.Categories.ToList();
    foreach (var c in categories)
    product.Categories.Remove(c);
    
    context.SaveChanges();
    
    
    // To add a new product:
    var product = new Product() { Name = "Cool product", Code = "4&meridians", price = 5.0 };
    
    context.Products.Add(product);
    context.SaveChanges();
