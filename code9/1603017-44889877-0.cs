    var query = dbContext.MyEntity;
    if (someField != null)
    {
        query = query.Where(d=>d.SomeField = someField);
    }
    if (someOtherField != null)
    {
        query = query.Where(d=>d.SomeOtherField = someField);
    }
    if (mustOrder != null)
    {
        query = query.OrderBy(d=>d.OrderField);
    }
    //Execute the final query
    return query.ToList();
