	public static bool TestIs1<T1, T2>()
	{
		var arr = new T1[0];
		return arr is T2[];
	}
	Console.WriteLine(TestIs1<int, uint>());
	var arr = new int[0];
	Console.WriteLine(arr is uint[]);
