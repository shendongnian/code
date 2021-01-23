    static List<List<T>> spliT<T>(this List<T> list, T separator = default(T), int start = 0)
    {
        var lists = new List<List<T>>();
        for (int i = start; i < list.Count; i++)
            if (list[i].Equals(separator))
            {
                lists.Add(list.GetRange(start, i - start));
                start = i + 1;
            }
        lists.Add(list.GetRange(start, list.Count - start));
        return lists;
    }
