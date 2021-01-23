	var finalOutputStrings = new List<string>();
	foreach (string word in words)
	{
		wordNumCount++;
		// Lowercase the input word to recognise capitals
		var s = word.ToLower();
		// List to store the found characters
		var foundChar = new List<char>();
		// Iterate around each char in the word to retain the desired order
		foreach (var character in s.Where(c => findChar.Contains(c.ToString())))
		{
			foundChar.Add(character);
		}
		// Part of the output string containing the found characters
		var charString = (foundChar.Count > 0) ? string.Join(" ", foundChar) : " _ ";
		Console.WriteLine($"({wordNumCount}) [{word}] [{charString}]");
		finalOutputStrings.Add(charString.Replace(" ", ""));
	}
	var outputString = string.Join(" ", finalOutputStrings);
	Console.WriteLine($"Result output: [{outputString}] ");
