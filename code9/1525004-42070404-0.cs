    var parameter = Expression.Parameter(typeof(TEntity), "o"); // o =>
    var left = Expression.PropertyOrField(parameter, _efRangeEndPropName); // o.Property
    var right = Expression.Constant(null, left.Type); // null
    var condition = Expression.Equal(left, right); // o.Property == null
    var predicate = Expression.Lambda<Func<TEntity, bool>>(condition, parameter);
