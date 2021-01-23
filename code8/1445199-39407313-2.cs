    public static List<User> FilterDistinct<TKey>(this IEnumerable<User> source, Func<User, TKey> keySelector)
    {
        return source
            .Where(x => keySelector(x) != null && keySelector(x).ToString() != string.Empty)
            .GroupBy(keySelector)
            .Select(g => g.First())
            .ToList();
    }
