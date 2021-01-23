    var query = _dbSet.Where(criteria)
                      .OrderByDescending(OrderBy);
    if (ThenOrderBy!=null)
    {
        query = query.ThenBy(ThenOrderBy);
    }
    var result = query.ToList();
