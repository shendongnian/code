    public static class Extensions
    {
        public static bool AreAllPropertiesNotNullForAllItems<T>(this IEnumerable<T> items)
        {
            var properties = typeof(T).GetProperties();
            return items.All(x => properties.All(p => p.GetValue(x) != null));
        }
    }
