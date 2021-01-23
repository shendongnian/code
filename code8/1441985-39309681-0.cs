	void Main()
	{
		var arr = new[] { 1, 2, 3 };
		NumberList(arr, arr);
	}
	
	public static void NumberList(params int[][] numbers)
	{
		foreach (var number in numbers.SelectMany(x => x))
		{
			Console.WriteLine(number);
		}
	}
