    public static class ListExtensions
    {
        public static T ElementAtOrDefault<T>(this IList<T> list, int index, T defaultValue)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(string.Format("index = {0}", index));
            if (list == null || index >= list.Count)
                return defaultValue;
            return list[index];
        }
    }
