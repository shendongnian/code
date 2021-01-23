    public static class ExtensionMethods
    {
        //This is the only one you need for your example, but I added all 3 versions.
        public static async Task<bool> AllAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            foreach (var item in source)
            {
                var result = await predicate(item);
                if (!result)
                    return false;
            }
            return true;
        }
        public static async Task<bool> AllAsync<TSource>(this IEnumerable<Task<TSource>> source, Func<Task<TSource>, Task<bool>> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            foreach (var item in source)
            {
                var result = await predicate(item);
                if (!result)
                    return false;
            }
            return true;
        }
        public static async Task<bool> AllAsync<TSource>(this IEnumerable<Task<TSource>> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            foreach (var item in source)
            {
                var awaitedItem = await item;
                if (!predicate(awaitedItem))
                    return false;
            }
            return true;
        }
    }
