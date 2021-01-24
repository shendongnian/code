	public static class Ex
	{
		public static void Using<T, R>(this T obj, Func<T, R> create, Action<T, R> use) where R : IDisposable
		{
			using (var d = create(obj))
			{
				use(obj, d);
			}
		}
	}
