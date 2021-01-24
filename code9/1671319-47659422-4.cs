    public static class LinqExtensions
    {
        public static IQueryable<T> OrderByName<T>(this IQueryable<T> queryable, string sortOrder = null)
        {
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "ASC";
            }
            return queryable.OrderBy(string.Format("Name {0}", sortOrder));
        }
    }
