    if (ids.Count() != 0)
    {
       var property = (PropertyInfo)((MemberExpression)propertySelector.Body).Member;
    
        ParameterExpression parameter = Expression.Parameter(typeof(T));
    
        var expression = Expression.Lambda<Func<T, bool>>(
            Expression.Not(
                Expression.Call(
                    Expression.Constant(ids),
                    typeof(ICollection<int>).GetMethod("Contains"), 
                    Expression.Property(parameter, property))), 
            parameter);
    
        return entities.Where(expression);
    }
    return new List<T>().AsQueryable()//Or Enumerable.Empty<T>().AsQueryable();
