    public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortColumn, string direction) {
        var methodNameFirst = string.Format("OrderBy{0}", direction.ToLower() == "asc" ? "" : "descending");
        var methodNameContinue = string.Format("ThenBy{0}", direction.ToLower() == "asc" ? "" : "descending");
        ParameterExpression parameter = Expression.Parameter(query.ElementType, "p");
        Expression result = query.Expression;
        var methodName = methodNameFirst;
        foreach (var fields in sortColumn.Split(',')) {
            Expression memberAccess = null;
            foreach (var property in fields.Split('.')) {
                memberAccess = MemberExpression.Property(memberAccess ?? (parameter as Expression), property);
            }
            LambdaExpression orderByLambda = Expression.Lambda(memberAccess, parameter);
            result = Expression.Call(
                typeof(Queryable),
                methodName,
                new[] { query.ElementType, memberAccess.Type },
                result,
                Expression.Quote(orderByLambda));
            methodName = methodNameContinue;
        }
        return query.Provider.CreateQuery<T>(result);
    }
