    public static class ListExtensions
    {
        public static bool TryGetIndexOf<T>(this IList<T> source, T item, out int index)
        {
            if(source == null) throw new ArgumentNullException(nameof(source));
            index = source.IndexOf(item);
            return index != -1;
        }
    }
