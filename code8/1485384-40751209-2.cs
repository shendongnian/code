    public static class EnumerableExtension
    {
        public static IEnumerable<TSource> ConcatOrSkipNull<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null)
               first = new List<TSource>();
            if (second == null)
                return first;
            return first.Concat(second);
        }
    }
