    var query = _dbSet.Where(criteria);
    var orderedQuery=OrderDescending 
                           ?query.OrderByDescending(OrderBy)
                           :query.OrderBy(OrderBy);
    if (buscaPaginada)
    {
        if (Skip > 0)
        {
            query = query.Skip(Skip);
        }
        if (Take >0)
        {
            query = query.Skip(Skip);
        }
    }
    return query.ToList();
