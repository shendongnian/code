	public static class GenericExtensions
	{
		public static T ThrowIfNull<T>(this T obj, string message)
		{
			if (obj == null) 
				throw new HttpException(404,
				   string.Format(Resources.GenericNotFound, message));
			return obj;
		}
	}
	
