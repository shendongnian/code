	public static class ExtensionMethods
	{
		static public IEnumerable<T> Minus<T>(this IEnumerable<T> input, IEnumerable<T> removal)
		{
			var result = input.ToList();
			foreach (var r in removal) result.Remove(r);
			return result;
		}
	}
	
