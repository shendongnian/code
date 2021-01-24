	int originalInput = 42;
	int input = originalInput;
	
	// Generate binary numbers
	var binaryNumbers = Enumerable.Range(0, 31).Select(n => (int)Math.Pow(2, n)).ToArray();
	
	// Largest first
	Array.Reverse(binaryNumbers);
	
	var result = new List<int>();
	
	foreach (var bin in binaryNumbers)
	{
		if (input >= bin)
		{
			result.Add(bin);
			input -= bin;
		}
	}
	
	Console.WriteLine($"{originalInput} decomposed: " + string.Join(" ", result));
