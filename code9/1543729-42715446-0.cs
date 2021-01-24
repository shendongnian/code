    var par = Expression.Parameter(typeof(object), "row");
    // load the map once
    foreach (var propertyInfo in propertyInfos)
    {
        Func<object, object> func = Expression.Lambda<Func<object, object>>(Expression.Convert(Expression.Property(Expression.Convert(par, propertyInfo.DeclaringType), propertyInfo), typeof(object)), par).Compile();
        map.Add(propertyInfo.Name, func);
    }
