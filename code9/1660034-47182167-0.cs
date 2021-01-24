	public static T AllocateMemory<T>(Func<T> func) where T: new()
	{
		try
		{
			return func();;
		}
		catch (System.OutOfMemoryException e)
		{
			Console.WriteLine("Generic memory error " + e.ToString());
			return default(T);
		}
	}
