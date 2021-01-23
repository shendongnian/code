    public delegate bool TryParseHandler<T>(string value, out T result);
	
	public static T? DbNullOrValue<T>(this string input, TryParseHandler<T> handler) where T : struct, IConvertible
	{
		T res;
		if (!string.IsNullOrEmpty(input))
			if(handler(input, out res))
				return res;
		return null;
	}
