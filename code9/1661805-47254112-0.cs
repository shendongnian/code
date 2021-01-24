	void Main()
	{
		var methods_list = new List<Func<bool>>();
		methods_list.Add(() => methodOne());
	
		// prints true
		Console.WriteLine(methods_list[0].Invoke());
	}
	
	public static bool methodOne()
	{
		return true;
	}
