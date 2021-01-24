    public static TValue GetSafe<TItem>(this IList<TItem> list, 
    int index, TValue defaultValue)
    {
        if (index < 0 || index >= list.Count)
        {
           return defaultValue;
        }
        return list[index];
    }
