    public static T2 ItemInOtherCollection<T1, T2>(this IEnumerable<T1> items, IEnumerable<T2> otherItems, T1 item)
    {
        var list = items.ToList();
        return otherItems.ElementAt(list.IndexOf(item));
    }
