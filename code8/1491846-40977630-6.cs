    // using Z.Expressions; // Don't forget to include this.
    // The filterQuery must use the C# syntax
    string filterQuery = "x.Id == 1 && x.Number = 2";
    
    IQueryable<Publication> query = db.Publications.Include(i => i.Product);
    query = query.Where(x => filterQuery);
