    public static class ObjectExtensions
    {
        public static bool In<T>(this T item, params T[] elements)
        {
            return elements.Contains(item);
        }
    }
