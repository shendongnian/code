    public static Expression<Func<IQueryable<TS>,IOrderedQueryable<TS>>> MyOrderByLambda<TS>(IQueryable<TS> _, string propertyName) {
        //Create x=>x.PropName
        var argx = Expression.Parameter(typeof(TS), "x");
        var property = Expression.PropertyOrField(argx, propertyName);
        var selector = Expression.Lambda(property, new ParameterExpression[] { argx });
        //Create s=>s.OrderBy<TS, propertyInfo.Type>(x => x.@propertyName)
        var args = Expression.Parameter(typeof(IQueryable<TS>), "s");
        var genericOrderByMI = typeof(Queryable).GetMethods(BindingFlags.Static|BindingFlags.Public).First(mi => mi.Name == "OrderBy" && mi.GetParameters().Length == 2);
        var orderByMI = genericOrderByMI.MakeGenericMethod(typeof(TS), property.Type);
        var orderbybody = Expression.Call(orderByMI, args, selector);
        var orderbyLambda = Expression.Lambda<Func<IQueryable<TS>, IOrderedQueryable<TS>>>(orderbybody, new ParameterExpression[] { args });
        return orderbyLambda;
    }
