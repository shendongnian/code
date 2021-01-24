	public static void Main()
	{
		int[] numbers = new int[]{1, 2, 3, 4};
		var val1 = numbers.GetValue(3);
		var type = val1.GetType();
		var val2 = numbers[3];
		
		Console.WriteLine(type.ToString());
		val1 = "hello";
		type = val1.GetType();
		Console.WriteLine(type.ToString());
	}
