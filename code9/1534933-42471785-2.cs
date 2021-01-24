    private static Func<object[], P> getMaterializer<P>(
        System.Reflection.PropertyInfo[] props, IEnumerable<string> propertyNames)
    {
        Type[] propertyTypes = props.Select(p => p.PropertyType).ToArray();
        ParameterExpression arrExpr = Expression.Parameter(typeof(object[]));
        var constructor = typeof(P).GetConstructor(propertyTypes);
        if (constructor == null || !constructor
            .GetParameters()
            .Select(p => p.Name)
            .SequenceEqual(propertyNames))
        {
            return null;
        }
        Expression[] paramExprList = propertyTypes.Select((type, i) =>
        {
            Expression ei = Expression.ArrayIndex(arrExpr, Expression.Constant(i));
            if (type.IsGenericType || type == typeof(string))
            {
                return (Expression)Expression.Condition(
                    Expression.Equal(ei, Expression.Constant(DBNull.Value)),
                    Expression.Convert(Expression.Constant(null), type),
                    Expression.Convert(ei, type)
                    );
            }
            else
            {
                return Expression.Convert(ei, type);
            }
        }).ToArray();
        return Expression.Lambda<Func<object[], P>>(
            Expression.New(constructor, paramExprList),
            arrExpr
            ).Compile();
    }
    private static System.Collections.Concurrent.ConcurrentDictionary<Type, Tuple<string, string, object>> cachedProjections =
        new System.Collections.Concurrent.ConcurrentDictionary<Type, Tuple<string, string, object>>();
    private static Tuple<string, string, object> getProjection<T, P>()
    {
        Type typeP = typeof(P);
        Tuple<string, string, object> projection;
        if (!cachedProjections.TryGetValue(typeP, out projection))
        {
            Type typeT = typeof(T);
            System.Reflection.PropertyInfo[] props = typeP.GetProperties();
            List<string> propertyNames = props.Select(p => p.Name).ToList();
            projection = new Tuple<string, string, object>(
                string.Join(",", propertyNames),
                typeT.Name,
                typeT == typeP ? null : getMaterializer<P>(props, propertyNames)
                );
            cachedProjections.TryAdd(typeP, projection);
        }
        return projection;
    }
    private static IEnumerable<P> Materialize<P>(SqlCommand cmd,
        Func<object[], P> materializer)
    {
        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        {
            object[] obj = new object[reader.VisibleFieldCount];
            while (reader.Read())
            {
                reader.GetValues(obj);
                yield return materializer(obj);
            }
        }
    }
    public static IEnumerable<P> ProjectionFunction<T, P>(
        this System.Data.Linq.Table<T> input,
        Func<T, P> projectionFunction
     ) where T : class
    {
        var projection = getProjection<T, P>();
        using (SqlCommand cmd = new SqlCommand(
           "SELECT " + projection.Item1
           + " FROM " + projection.Item2,
           new SqlConnection(input.Context.Connection.ConnectionString)
           ))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            var materializer = (Func<object[], P>)projection.Item3;
            if (materializer == null)
            {
                return input.Context.Translate<P>(cmd.ExecuteReader(CommandBehavior.CloseConnection));
            }
            else
            {
                return Materialize(cmd, materializer);
            }
        }
    }
