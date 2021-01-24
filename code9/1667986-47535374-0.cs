    public static class IQueryableExtensions
    {
        public static IQueryable<T> Expand<T>(this IQueryable<T> source, string navigationProperty)
        {
            var dsq = (DataServiceQuery<T>)source;
            return dsq.Expand(navigationProperty);
        }
    }
