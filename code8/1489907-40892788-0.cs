    public static List<T> PrependAll<T>(this List<T> list, Func<T, bool> predicate)
    {
        var returnList = new List<T>();
        var listNonMatch = new List<T>();
        foreach (T item in list)
        {
            if (predicate(item))
                returnList.Add(item);
            else
                listNonMatch.Add(item);
        }
        returnList.AddRange(listNonMatch);
        return returnList;
    }
