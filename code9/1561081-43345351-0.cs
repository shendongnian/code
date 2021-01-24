    public static class Extensions
    {
        public static bool None(this IEnumerable<T> source, Func<T, bool> predicate)
            => !source.Any(predicate);
    }
