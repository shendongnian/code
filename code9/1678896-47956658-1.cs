    switch (<field type>) {
    
    case <type is double>:
      return _dbSet.AsNoTracking()
                            .OrderByDescending(GetSortExpression<Enitity, double>(FieldName))
                            .ToList();
    case <type is int>:
      return _dbSet.AsNoTracking()
                            .OrderByDescending(GetSortExpression<Enitity, int>(FieldName))
                            .ToList();
