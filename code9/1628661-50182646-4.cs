    public static class QueryableExtensions
    {
        public static IIncluder Includer = null;
        public static IIncludableQueryable<T, TProperty> Include<T, TProperty>(
            this IQueryable<T> source,
            Expression<Func<T, TProperty>> path
        )
            where T : class
        {
            return Includer.Include(source, path);
        }
    }
