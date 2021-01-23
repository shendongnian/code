    // Base query including static filters
    var query = db.PageStats.AsQueryable();
    // Apply dynamic filters
    if (!vm.CMS.Equals("All"))
        query = query.Where(x => x.Source.Equals(vm.CMS));
    // ...
    // The rest of the query
    query = query.Select(...
