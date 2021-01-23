	var finalOutputStrings = new List<string>();
	foreach (string word in words)
	{
		wordNumCount++;
		// Lowercase the input word to recognise capitals
		var s = word.ToLower();
		// List to store the found characters
		var foundChar = new List<char>();
		// Iterate around each char in the word to retain the desired order
		for (int i = 0; i < s.Count(); i++)
		{
			if (findChar.Contains(s[i].ToString()))
			{
				foundChar.Add(s[i]);
			}
		}
		// Part of the output string containing the found characters
		var charString = string.Empty;
        // Building the output string for this word
		if (foundChar.Count > 0)
		{
			charString = string.Join(" ", foundChar);
		}
		else
		{
			charString = " _ ";
		}
		Console.WriteLine($"({wordNumCount}) [{word}] [{charString}]");
		finalOutputStrings.Add(charString.Replace(" ", ""));
	}
	var outputString = string.Join(" ", finalOutputStrings);
	Console.WriteLine($"Result output: [{outputString}] ");
