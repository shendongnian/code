    public static class EnumerableSetExtensions
    {
        public static IEnumerable<T> SetExcept<T>(this IEnumerable<T> source, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }
            var secondDict = second
                .GroupBy(
                    keySelector: e => e,
                    comparer: comparer)
                .ToDictionary(
                    keySelector: e => e.Key,
                    elementSelector: e => e.Count(),
                    comparer: comparer);
            foreach (var item in source)
            {
                if (secondDict.ContainsKey(item))
                {
                    var itemcount = secondDict[item] -= 1;
                    if (itemcount == 0)
                    {
                        secondDict.Remove(item);
                    }
                }
                else
                    yield return item;
            }
        }
        public static IEnumerable<T> SetExcept<T>(this IEnumerable<T> source, IEnumerable<T> second)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }
            return SetExcept(source, second, EqualityComparer<T>.Default);
        }
    }
