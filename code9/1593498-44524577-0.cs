    public static class StringCollectionExtensions
    {
        public static bool HasLengthLessThan(this IEnumerable<string> collection, int length)
        {
            return collection.Any(x => x.Length < length);
        }
    }
