    public static class EnumerablePropertyAccessorExtensions
    {
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> enumerable, string property)
        {
            return enumerable.OrderBy(x => GetProperty(x, property));
        }
        private static object GetProperty(object o, string propertyName)
        {
            return o.GetType().GetProperty(propertyName).GetValue(o, null);
        }
    }
