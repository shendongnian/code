    // a =>
    var param = Expression.Parameter(typeof(T), "a");                    
    // a => a.ColumnName
    var prop = Expression.Property(param, columnName);                    
    // s => s.Contains(term)
    Expression<Func<string, bool>> contains = (string s) => s.Contains(term);
    // extract body - s.Contains(term)
    var containsBody = (MethodCallExpression)contains.Body;                    
    // replace "s" parameter with our property - a.ColumnName.Contains(term)
    // Update accepts new target as first parameter (old target in this case is 
    // "s" parameter and new target is "a.ColumnName")
    // and list of arguments (in this case it's "term" - we don't need to update that).
    // 
    var call = containsBody.Update(prop, containsBody.Arguments);
    columnFilter = columnFilter.Or(Expression.Lambda<Func<T, bool>>(call, param));
