    var nhibernateQuery = session
        .Query<Entity>();
    
    if (!string.IsNullOrWhiteSpace(query))
    {
        nhibernateQuery = nhibernateQuery
            .Where(e => e.Value.Contains(query) || e.Child.Value.Contains(query));
    }
    
    return nhibernateQuery.ToArray();
