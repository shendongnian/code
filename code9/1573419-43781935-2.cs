    var query = DBContext.EventDocuments;
    
    if(!string.IsNullOrEmpty(SearchFirstName))
    {
        query = query.Where(x => x.FirstName.Contains(SearchFirstName));
    }
    if(!string.IsNullOrEmpty(SearchLastName))
    {
        query = query.Where(x => x.LastName.Contains(SearchLastName));
    }
    
    var result = query.ToList();
