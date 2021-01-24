    var property = "power_usage"; // I set this dynamically.
    var entityType = typeof(system_state);
    var prop = entityType.GetProperty(property);
    var source = Expression.Parameter(entityType, "ss");
    var func = typeof(Func<,>);
    var genericFunc = func.MakeGenericType(typeof(system_state), prop.PropertyType);
    var baseQuery = context.system_state
                .Where(ss => ss.time_stamp >= StartDate && ss.time_stamp <= EndDate);
    var exp = Expression.Lambda(Expression.Property(source, prop), source);
    MethodInfo select = selectT.MakeGenericMethod(entityType, prop.PropertyType);
    IQueryable query = (IQueryable)select.Invoke(null, new object[] { baseQuery, exp });
    var result = query.Cast<object>().ToArray();
