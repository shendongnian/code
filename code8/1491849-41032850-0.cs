    List<Publication> results = new List<Publication>();
    
    // Just an example, previously calculated dynamically
    string filterQuery = "(Id = 1 and Number = 2)";
    string filterQueryChildren = "Products.Any(Id == 1)"
    
    IQueryable<Publication> query = db.Publications.Include(i => i.Product).Where(filterQueryChildren);
    
    query = query.Where(filterQuery);
    
    results = query.OrderBy(orderQuery).ToList();
