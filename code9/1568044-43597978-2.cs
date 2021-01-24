    public static class CollectionExtensions
    {
        public static IList<T> GetNewOrModifiedItems<T, TKey>(
            this IList<T> newItems,
            IList<T> oldItems,
            Func<T, TKey> getKey,
            IEqualityComparer<T> comparer)
        {
            oldItems = oldItems ?? new List<T>();
            newItems = newItems ?? new List<T>();
            var oldItemsDictionary = oldItems.ToDictionary(getKey);
            var results = new List<T>();
            foreach (var item in newItems)
            {
                if (!oldItemsDictionary.ContainsKey(getKey(item)) ||
                    !comparer.Equals(item, oldItemsDictionary[getKey(item)]))
                {
                    results.Add(item);
                }
            }
            return results;
        }
    }
