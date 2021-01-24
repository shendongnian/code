    public static class QueryableExtensions {
        public static IQueryable<TEntity> WhereIn<TEntity, TValue>(this IQueryable<TEntity> query, string property, IEnumerable<TValue> values) {
            // x
            var arg = Expression.Parameter(typeof(TEntity), "x");
            // x.Property            
            var prop = Expression.Property(arg, property);
            // values.Contains(x.Property)
            var contains = Expression.Call(
                typeof(Enumerable),
                "Contains",
                new[] { typeof(TValue) },
                Expression.Constant(values),
                prop
            );
            // x => values.Contains(x.Property)
            var lambda = Expression.Lambda<Func<TEntity, bool>>(contains, arg);
            return query.Where(lambda);
        }
    }
