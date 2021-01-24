    static class IListExtensions
    {
        public static T FindItemAfter<T>(this IList<T> list, T targetItem)
        {
            return list[list.IndexOf(targetItem)+ 1];
        }
    }
