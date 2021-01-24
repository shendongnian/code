    static class EnumerableExtensions
    {
        public static bool IsUnique<TSource, TKey>(this TSource source, 
            Func<TSource, TKey> propertySelector)
        {
             return !source.Select(propertySelector)
                 .Distinct()
                 .Skip(1)
                 .Any();
        }
    }
