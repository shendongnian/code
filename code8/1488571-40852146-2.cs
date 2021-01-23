    static class Extensions
    {
        public static IEnumerable<T> TrimTrailing<T>(this IEnumerable<T> items,
                                                     Predicate<T> test)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (test == null) throw new ArgumentNullException(nameof(test));
            var buf = new List<T>();
            foreach (T item in items)
            {
                if (test(item))
                {
                    buf.Add(item);
                }
                else
                {
                    foreach (T bufferedItem in buf)
                    {
                        yield return bufferedItem;
                    }
                    buf.Clear();
                    yield return item;
                }
            }
        }
    }
