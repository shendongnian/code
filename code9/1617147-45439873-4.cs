	public string Truncate(string input, string match, int nbCharMaxBefore, int nbCharMaxAfter)
	{  
		var inputSplit = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
		var index = 0;
		while (index < inputSplit.Length)
		{
			if (inputSplit[index].Contains(match)) break;
			index++;
		}
		if (index == inputSplit.Length)
		{
			// No match
			return String.Empty;
		}
		// Adds all the words before the match as long as the sum of all the words is not greater than the specified limit
		var previousWords = new List<string>();
		var i = index - 1;
		while (i >= 0)
		{
			var previousWord = inputSplit[i];
			if (previousWord.Length + previousWords.Sum(w => w.Length) < nbCharMaxBefore)
			{
				previousWords.Insert(0, previousWord);
			}
			else
			{
				break;
			}
			i--;
		}
		// Adds all the words after the match as long as the sum of all the words is not greater than the specified limit
		var nextWords = new List<string>();
		i = index + 1;
		while (i < inputSplit.Length)
		{
			var nextWord = inputSplit[i];
			if (nextWord.Length + nextWords.Sum(w => w.Length) < nbCharMaxAfter)
			{
				nextWords.Add(nextWord);
			}
			else
			{
				break;
			}
			i++;
		}
		var prev = String.Join(" ", previousWords);
		var next = String.Join(" ", nextWords).TrimEnd(',');
		return $"...{prev} {inputSplit[index]} {next}...";
	}
