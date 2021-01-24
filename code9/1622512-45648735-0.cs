    public static class LinqExtentions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection,
           Func<T, bool> predicate, 
           int numToFilter = 1)
        {
            var count = 0;
            return collection.Where(x => predicate(x) || count++ > numToFilter - 1).ToList();
        }
    }
