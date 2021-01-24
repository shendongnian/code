    public static class ExpressionExt
        {
            public static IQueryable<T> Where<T,TKey>(this IQueryable<T> data, string prop,params TKey[] guids)
            {
                var param = Expression.Parameter(typeof(T));
                var exp = guids.Select(g => Expression.Equal(Expression.Property(param, prop), Expression.Constant(g))).Aggregate((a, e) => a != null ? Expression.Or(e, a) : e);
                var lambda = Expression.Lambda<Func<T, bool>>(exp, param);
    
                return data.Where(lambda);
            }
        }
