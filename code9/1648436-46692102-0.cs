    public static ICollection<T> CreateCopyReflection<T> (this ICollection<T> c)
    {
        var n = (ICollection<T>) Activator.CreateInstance (c.GetType());
        foreach (var item in c)
            n.Add (item);
        return n;
    }
    public static IEnumerable<T> CreateCopyLinq<T> (this IEnumerable<T> c) => c.Select (arg => arg);
    public static IEnumerable<T> CreateCopyEnumeration<T> (this IEnumerable<T> c)
    {
        foreach (var item in c)
            yield return item;
    }
