    public static void Main()
	{
		var originalList  = new List<string>()
		{
			@"AAA\BBB",
			@"AAA\CCC",
			@"AAA\CCC",
			@"BBB\XXX",
			@"BBB",
			@"BBB\XXX",
			@"BBB\XXX"
		};
		
		var outputList = originalList.GroupBy(x => x).SelectMany(x => x.Select((y, i) => string.Format("{0}[{1}]", y, i + 1)));		
		
		Console.WriteLine(string.Join("\n", outputList));
	}
