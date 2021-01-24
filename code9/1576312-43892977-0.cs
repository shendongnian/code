    public static class MyWhereHelper
    {
        public static readonly MethodInfo WhereMethod = typeof(MyWhereHelper).GetMethod("Where", BindingFlags.Static | BindingFlags.Public);
        public static List<T> Where<T>(IQueryable<T> baseQuery, Expression<Func<T, bool>> where)
        {
            return baseQuery.Where(where).ToList();
        }
    }
