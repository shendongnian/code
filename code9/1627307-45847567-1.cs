    var whereCallExpression = Expression.Call(
        typeof(Queryable),
        "Where",
        new Type[] { query.ElementType },
        query.Expression,
        Expression.Quote(lambda));
