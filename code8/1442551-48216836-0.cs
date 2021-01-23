    public enum LinqProvider
    {
        Linq2SQL, Linq2Objects
    }
    public static class LinqProviderExtensions
    {
        public static LinqProvider LinqProvider(this IQueryable query)
        {
            if (query.Provider.GetType().IsGenericType && query.Provider.GetType().GetGenericTypeDefinition() == typeof(EnumerableQuery<>))
                return LinqProvider.Linq2Objects;
            if (typeof(ICollection<>).MakeGenericType(query.ElementType).IsAssignableFrom(query.GetType()))
                return LinqProvider.Linq2Objects;
            return LinqProvider.Linq2SQL;
        }
    }
