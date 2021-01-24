    for (var i = 1; i <= last - 1; i++)
    {
        // No inner loop
        // Use the .Contains() method to see if it's a key word
        if (listToCheck.Contains(words[i]))
	    {
            wordsList.AddLast(LowercaseWord(words[i]));
        }
        else
        {
            wordsList.AddLast(CapitalizeWord(words[i]));
        }
    }
