    static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Combine<T>(this IEnumerable<IEnumerable<T>> listOfLists)
        {
            IEnumerable<IEnumerable<T>> seed = new List<List<T>> { new List<T>() };
            return listOfLists.Aggregate(seed, (r, list) => 
                r.SelectMany(a => list.Select(x => a.Append(x))));
        }
        
        public static IEnumerable<T> Append<T>(this IEnumerable<T> list, params T[] elements)
        {
            return list == null ? elements : list.Concat(elements);
        }
    }
