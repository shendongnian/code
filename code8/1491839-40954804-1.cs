    List<Publication> results = new List<Publication>();
    
    // Just an example, previously calculated dynamically
    string filterQuery1 = "(Id = 1)"
    string filterQuery2 = "(Id = 1 and Number = 2)";
    
    IQueryable<Publication> query = db.Publications.
    Where(filterQuery1).     
    Include(i => i.Product);
    query = query.Where(filterQuery2);
    
    results = query.OrderBy(orderQuery).ToList();
