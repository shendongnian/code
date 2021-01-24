	static void Main()
	{
		var threeWords = new Regex(@"^(\w+),\1,\1$");
		var lines = new[]
		{
			"HEY,HEY,HEY",
			"NO,NO,NO",
			"HEY,HI,HEY",
			"HEY,H,Y",
			"HEY,NO,HEY",
		};
		
		foreach (var line in lines)
		{
			var isMatch = threeWords.IsMatch(line) ? "" : "no ";
			Console.WriteLine($"{line} - {isMatch}match");
		}
	}
