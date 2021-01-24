    public static class Ext
    {
        public static void RemoveAll(this IList<T> list, IEnumerable<T> toRemove)
        {
            ... // remove items matching toRemove from the list
        }
