	public static class Ext
	{
		public static Func<T, TProp> CreateGetPropertyFunc<T, TProp>(this T obj, Expression<Func<T, TProp>> expr)
		{
			return expr.Compile();
		}
	}
