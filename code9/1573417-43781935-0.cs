    var query = DBContext.EventDocuments;
    
    if(string.IsNullOrEmpty(SearchFirstName)
    {
        query.Where(x => x.FirstName == SearchFirstName);
    }
    if(string.IsNullOrEmpty(SearchLastName)
    {
        query.Where(x => x.LastName== SearchLastName);
    }
    
    var result = query.ToList();
