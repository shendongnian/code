    public static IEnumerable<IList<T>> Split<T>(this IEnumerable<T> collection, T seperator)
    {
        var items = new List<T>();
        foreach (var item in collection)
        {
            if (item.Equals(seperator))
            {
                yield return items;
                items = new List<T>();
            }
            else items.Add(item);
        }
        yield return items;
    }
