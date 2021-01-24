    static class EnumerableEx
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, out bool success)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            foreach (T ele in source)
            {
                if (predicate(ele))
                {
                    success = true;
                    return ele;
                }
            }
            success = false;
            return default(T);
        }
    }
