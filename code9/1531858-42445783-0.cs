    public static class Extensions
    {        
        public static IList<T> PagedList<T>(this IList<T> source, int pageIndex, int pageSize)
        {
            var list = new List<T>();
            list.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
            return list;
        }
    }
