    static class IListExtensions
    {
        public static T FindItemAfter<T>(this IList<T> list, T currentItem)
        {
            return list[list.IndexOf(currentItem)+ 1];
        }
    }
