    var p = Expression.Parameter(typeof(T), "p");
    var test = Expression.Lambda<Func<T, bool>>(
        Expression.Equal(
            Expression.PropertyOrField(p, matcherProp),
            Expression.PropertyOrField(Expression.Constant(ent), matcherProp),
        ), p);
