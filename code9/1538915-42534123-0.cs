    public static ICollection<T> Replace<T>(this IEnumerable<T> list, T oldValue, T newValue) where T : class
    {
        if (list == null)
            throw new ArgumentNullException(nameof(list));
        var collection = list as ICollection<T>;
        if (collection == null)
           throw new ArgumentException(nameof(list));
        collection.Remove(oldValue);
        collection.Add(newValue);
        return collection;
    }
