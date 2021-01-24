    public static class Extentions
    {
        public static IEnumerable<T> NotIn<T>(this IEnumerable<T> list, IEnumerable<T> filterList)
        {
            return list.Where(v => !filterList.Contains(v));
        }
    }
