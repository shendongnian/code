	public static void Main()
	{
		var someNumbers = new [] { 10,67,45,26,78,53,12,45,68};
		var groupNames = new [] { "A", "B", "C", "D" };
		
		var result = someNumbers.GroupBy(v => v / 25, p => p);
		
		foreach(var v in result.OrderBy(i => i.Key))
		{
            // check if the key can be used as index for the name array.
			if(v.Key >= groupNames.Length)
				Console.WriteLine(v.Key + " no name for that");
			else
				Console.WriteLine(groupNames[ v.Key]);
			
			foreach(var k in v)
				Console.WriteLine("  " + k);
		}
		
	}
