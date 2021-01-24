	public static class ExtensionMethods
	{
		static public IEnumerable<T> Minus<T>(this IEnumerable<T> input, IEnumerable<T> removal)
		{
			var remaining = removal.ToList();
			return input.Where
			(
				a => !remaining.Remove(a)
			);		
		}
    }
