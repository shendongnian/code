    // The Enumerable.Contains method
    private static readonly MethodInfo Contains = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                    where x.Name == nameof(Enumerable.Contains)
                                                    let args = x.GetGenericArguments()
                                                    where args.Length == 1
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                        pars[1].ParameterType == args[0]
                                                    select x).Single();
    public static IQueryable<TSource> In<TSource, TMember>(
        this IQueryable<TSource> source,
        Expression<Func<TSource, TMember>> identifier, params TMember[] values)
    {
        // Some argument checks
        if (source == null)
        {
            throw new NullReferenceException(nameof(source));
        }
        if (identifier == null)
        {
            throw new NullReferenceException(nameof(identifier));
        }
        if (values == null)
        {
            throw new NullReferenceException(nameof(values));
        }
        // We only accept expressions of type x => x.Something
        // member wil be the x.Something
        var member = identifier.Body as MemberExpression;
        if (member == null)
        {
            throw new ArgumentException(nameof(identifier));
        }
        // Enumerable.Contains<TMember>
        var contains = Contains.MakeGenericMethod(typeof(TMember));
        // Enumerable.Contains<TMember>(values, x.Something)
        var call = Expression.Call(contains, Expression.Constant(values), member);
        // x => Enumerable.Contains<TMember>(values, x.Something)
        var lambda = Expression.Lambda<Func<TSource, bool>>(call, identifier.Parameters);
        return source.Where(lambda);
    }
