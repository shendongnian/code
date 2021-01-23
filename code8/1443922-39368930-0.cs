    public static class MyEnumerable
    {
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
    
            var items = new HashSet<T>();
    
            foreach (T item in source)
            {
                if (items.Add(item))
                {
                    yield return item;
                }
            }
        }
    }
