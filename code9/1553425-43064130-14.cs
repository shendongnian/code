    public static IEnumerable<T> AddIfNotExists<T>(this IEnumerable<T> enumerable, params T[] value) 
    {
        HashSet<T> notExistentItems = new HashSet<T>(value);
        foreach (var item in enumerable)
        {
            if (notExistentItems.Contains(item))
                notExistentItems.Remove(item);
            yield return item;
        }
        foreach (var notExistentItem in notExistentItems)
            yield return notExistentItem;
    }
    // Usage example:
    int[] arr = new[] { 1, 2, 3 };
    arr = arr.AddIfNotExists(2, 3, 4, 5).ToArray(); // 1, 2, 3, 4, 5
