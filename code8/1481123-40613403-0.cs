    var propertyInfo = typeof(Data.Quote).GetProperty(sortName);
    
    ParameterExpression parameter = Expression.Parameter(typeof(T), "s");
    MemberExpression property = Expression.Property(parameter, propertyInfo);
    LambdaExpression sort = Expression.Lambda(property, parameter);
    
    MethodCallExpression call = Expression.Call(
                                             typeof(Queryable),
                                             "OrderBy",
                                             new[] {typeof(T), property.Type},
                                             source.Expression,
                                             Expression.Quote(sort));
    
    var orderedQuery = (IOrderedQueryable<T>)Query.Provider.CreateQuery<T>(call);
    
    PaginatedList = orderedQuery.Skip(skipValue).Take(pageSize);
