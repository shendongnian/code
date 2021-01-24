    public static IOrderedQueryable<T> OrderByNull<T>(IQueryable<T> srcQuery, string orderColumn, bool isAscending)
    {
        var type = typeof(T);
        var property = type.GetProperty(orderColumn);
    
        if (property == null)
            throw new Exception("Column property \"" + orderColumn + "\" does not exist on the type \"" + typeof(T).FullName + "\"");
    
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.Condition(
            Expression.Equal(Expression.MakeMemberAccess(parameter, property), Expression.Constant(null, property.PropertyType)),
            Expression.Constant(1),
            Expression.Constant(0));
    
        var orderByExp = Expression.Lambda(propertyAccess, parameter);
        MethodCallExpression resultExp =Expression.Call( typeof(Queryable), isAscending ? "OrderBy" : "OrderByDescending", new Type[] { type,  typeof(int) },
        srcQuery.Expression, Expression.Quote(orderByExp));
    
        return (IOrderedQueryable<T>)srcQuery.Provider.CreateQuery<T>(resultExp);
    }
