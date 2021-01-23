    public static void ForEach<T>(this System.Collection.Generic.IEnumerable<T> list, System.Action<T> action)
    {
        foreach (T item in list)
            action(item);
    }
