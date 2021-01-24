    public static class CollectionExtensions
    {
        public static IEnumerable<T> AddIfNotExists<T>(this IEnumerable<T> enumerable, T value) 
        {
            bool itemExists = false;
            foreach (var item in enumerable)
            {
                if (!itemExists && value.Equals(item))
                    itemExists = true;
    
                yield return item;
            }
    
            if (!itemExists)
                yield return value;
        }
    }
    // Example usage:
    string[] arr = ...;
    arr = arr.AddIfNotExists("Another Value").ToArray();
