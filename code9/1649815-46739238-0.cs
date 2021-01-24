	int numberOfRolls = 50;
	int diceSides = 6;
	int[] dice = new int[numberOfRolls];
	int[] match = new int[diceSides];
	Random random = new Random();
	Console.WriteLine("Press any key to roll the dice " + numberOfRolls + " times.");
	Console.ReadKey();
	for (int rollCount = 0; rollCount < numberOfRolls; rollCount++)
	{
		var rollResult = random.Next(1, diceSides+1);
		match[rollResult-1]++;
	}
	
	for (int i = 0; i < match.Length; i++)
	{
		Console.WriteLine(i+1 + " came up " + match[i] + " times.");
	}
	Console.ReadKey();
