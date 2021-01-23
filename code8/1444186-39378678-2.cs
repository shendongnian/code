    public static IEnumerable<T> MyExcept2<T>(this IEnumerable<T> orgList, IEnumerable<T> toRemove)
    {
        var list = orgList.OrderBy(x => x).ToList();
        foreach (var x in toRemove)
        {
            var inx = list.BinarySearch(x);
            if (inx > 0) list.RemoveAt(inx);
        }
        return list;
    }
