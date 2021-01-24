    IQueryable<StammdatenEntityModel> query = dbSet;
    query = query.OrderByDescending(s => s.CreateDateTime);
    query = query.Where(s => s.Deleted == false);
    if(!String.IsNullOrEmpty(keyword))
    {
        query = query.Where(s => s.SerialNumber.Contains(keyword)); //simplified for SO
    }
    query = query.Skip(skip);
    query = query.Take(take);
