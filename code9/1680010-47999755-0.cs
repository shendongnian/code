    public static class Extensions
    {
        public static List<I1> Downcast<T2>(this List<T2> list) where T2 : I1
        {
            return list == null ? null : list.Cast<I1>().ToList();
        }
    }
