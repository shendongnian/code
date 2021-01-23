    public static class EnumerableExtensions
    {
        public static IEnumerable<List<T>> Subdivide<T>(this IEnumerable<T> enumerable, int count)
        {
            List<T> items = new List<T>(count);
            int index = 0;
            foreach (T item in enumerable)
            {
                items.Add(item);
                index++;
                if (index != count) continue;
                yield return items;
                items = new List<T>(count);
                index = 0;
            }
            if (index != 0 && items.Any())
                yield return items;
        }
    }
    
