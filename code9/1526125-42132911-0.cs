    public static IEnumerable<T> SelectUntil<T>(this T element, Func<T, T> nextMemberSelector, Func<T, bool> stopCondition)
    {
        while (!stopCondition(element))
        {
            yield return element;
            element = nextMemberSelector(element);
        }
    }
    public static IEnumerable<Item> GetAncestors(this Item e)
    {
        // Or don't Skip(1) if you need the child itself included.
        return e.SelectUntil(T => T.Parent, T => T.Parent == null).Skip(1);
    }
    private static void Main(string[] args)
    {
        IEnumerable<Item> itemsQuery = GetQuery();
        IEnumerable<Item> filter = itemsQuery.Where(T => T.Code == "BBB");
        foreach (Item item in filter)
        {
            Item[] allParents = item.GetAncestors().ToArray();
        }
    }
