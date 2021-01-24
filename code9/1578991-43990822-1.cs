    public static IEnumerable<T> SomeBuiltInFunc<T>(this IEnumerable<T> enumerable, IEnumerable<T> item)
    {
        var list = enumerable.ToList();
        list.AddRange(item);
        return list;
    }
