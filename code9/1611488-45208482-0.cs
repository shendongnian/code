    static class Helper
    {
        public static T[] ToArray<T>(this ICollection collection)
        {
            var items = new T[collection.Count];
            collection.CopyTo(items, 0);
    
            return items;
        }
    }
