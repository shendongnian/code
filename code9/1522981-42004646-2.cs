    public static class EnumerablePropertyAccessorExtensions
	{
		public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> enumerable, string property)
		{
			var prop = typeof(T).GetProperty(property);
			return enumerable.OrderBy(x => GetProperty(x, prop));
		}
		
		private static object GetProperty(object o, PropertyInfo property)
		{
			return property.GetValue(o, null);
		}
	}
