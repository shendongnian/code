    var p = Expression.Parameter(typeof(T), "p");
    var val = GetPropValue(ent, matcherProp);
    var test = Expression.Lambda<Func<T, bool>>(
        Expression.Equal(
            Expression.PropertyOrField(p, matcherProp),
            Expression.Constant(val)
        ), p);
    if (t.Any(test))
        return InsertStatus.AlreadyExists;
    
