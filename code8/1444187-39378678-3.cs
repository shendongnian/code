    public static IEnumerable<T> MyExcept<T>(this IEnumerable<T> orgList, IEnumerable<T> toRemove)
    {
        var list = orgList.ToList();
        foreach(var x in toRemove)
        {
            list.Remove(x);
        }
        return list;
    }
