	public static class GenericExtensions
	{
		public static void ThrowIfNull<T>(this T obj, string message)
		{
			if (obj == null) throw new ArgumentNullException(message);
		}
	}
	
