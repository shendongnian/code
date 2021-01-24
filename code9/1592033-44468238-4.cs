	public static class TypeHelperExtensions
	{
		public static string GetTypeName<T>(this T Object)
		{
			return typeof(T).Name;
		}
	}
