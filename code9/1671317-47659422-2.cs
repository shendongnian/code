    public static class LinqExtensions
    {
        public static IEnumerable<T> OrderByName<T>(this IEnumerable<T> enumerable, string sortOrder = null)
        {
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "ASC";
            }
            return enumerable.OrderBy(string.Format("Name {0}",sortOrder));
        }
    }
