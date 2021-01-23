    public static class Extension
    {
        public static IEnumerable<T> Generate<T>(this IEnumerable<T> elements, Func<IEnumerable<T>> func)
        {
            if (func != null)
            {
                return func();
            }
            return Enumerable.Empty<T>();
        }
    }
