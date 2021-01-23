	public static class ObjectExtensions
	{
		public static void ThrowIfNull(this object obj, string message)
		{
			if (obj == null) throw new ArgumentNullException(message);
		}
	}
	
