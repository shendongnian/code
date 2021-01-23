    public static class Extensions
    {
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> source, T oldValue, T newValue)
        {
            return source.Select(element => element == oldValue ? newValue : element);
        }
    }
