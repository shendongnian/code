        public static class EnumerableExtension
        {
            public static IEnumerable<TSource> ConcatOrDefault<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
            {
                if (second == null)
                    return first;
                return first.Concat(second);
            }
        }
