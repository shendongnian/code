	public static void Main(string[] args)
	{
		Console.WriteLine("Please enter a value to search:");
		
		var toSearch = Console.ReadLine();
		var strings = GetOrderedArrayOfStrings(); // assuming here we have an ordered string[]
		var position = Binary_Search(strings, toSearch, Comparer<string>.Default);
		if(position == -1)
			Console.WriteLine("Not found");
		else
			Console.WriteLine($"Found at position {position}");
	}
