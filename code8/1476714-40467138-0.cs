    //Compose the query
    var results = _db.Where(item => item.Price > 10 );
    //still composing
    if(onlyNewItems)
    {
        results = results.Where(item => item.New);
    }
    //ToList() executes the query, data is returned;
    return results.ToList();
