    public static class Extensions {
        public static IEnumerable<T> ForceEnumerate<T>(this ICollection<T> collection) {
            foreach (var item in collection)
                yield return item;
        }
    }
