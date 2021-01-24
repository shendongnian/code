    public static IEnumerable<Thing> MatchBy(this IEnumerable<Thing> source, string keyName, IEnumerable<string> keys)
    {
        switch (keyName)
        {
            case nameof(Thing.Item1): return source.MatchBy(x => x.Item1, keys);
            // case ...
            default: throw new ArgumentOutOfRangeException(nameof(keyName));
        }
    }
