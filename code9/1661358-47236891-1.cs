    // we need to build entity => new Tuple<..>(entity.Property1, entity.Property2...)
    // arg represents "entity" above
    var arg = Expression.Parameter(typeof(TEntity));
    // The following part is where I need some help with...
    // Expression.Property(arg, "name) represents "entity.Property1" above
    var newTupleExpression = Expression.New(tupleConstructor, keyProperties.Select(c => Expression.Property(arg, c)));
    return Expression.Lambda<Func<TEntity, object>>(newTupleExpression, arg).Compile();
