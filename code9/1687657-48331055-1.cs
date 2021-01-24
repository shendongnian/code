    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> Unique<T>(
            this IEnumerable<T> sequence,
            Func<T, T, bool> match)
        {
            var list = sequence.ToList();
            return list
                .ToDictionary(arg => arg, arg => list.Count(item => match(item, arg)))
                .Where(pair => pair.Value == 1)
                .Select(pair => pair.Key);
        }
    }
