    private static readonly MethodInfo OrderByDescending = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                            where x.Name == "OrderByDescending"
                                                            let args = x.GetGenericArguments()
                                                            where args.Length == 2
                                                            let pars = x.GetParameters()
                                                            where pars.Length == 2 &&
                                                                pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(args[0]) &&
                                                                pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(args))
                                                            select x).Single();
    public static IQueryable<T> OrderByStringDescending<T>(this IQueryable<T> query, string parameter)
    {
        var par = Expression.Parameter(typeof(T), "obj");
        var selector = Expression.PropertyOrField(par, parameter);
        var lambda = Expression.Lambda(selector, par);
        return (IQueryable<T>)OrderByDescending.MakeGenericMethod(typeof(T), selector.Type).Invoke(null, new object[] { query, lambda });
    }
