    public static class MyExtensions
    {
        public static IQueryable<V> SelectByName<T, V>(this IQueryable<T> source, 
                                                            string FieldName)
        {
            ParameterExpression paramExp = Expression.Parameter(typeof(T), "x");
            MemberExpression memberExp = Expression.PropertyOrField(paramExp, FieldName);
            var lambdaExp = Expression.Lambda<Func<T, V>>(memberExp, paramExp);
    
            return source.Select(lambdaExp);
        }
    }
