    public static class HoldMyBeerAndWatchThis
    {
        public static IEnumerable<int> Select(Func<String, String> f)
        {
            yield return f("foo").Length;
        }
    }
