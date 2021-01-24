    for (var i = 1; i <= last - 1; i++)
    {
        bool foundMatch = false;
        foreach (var s in listToCheck)
        {
            if (words[i].Equals(s))
            {
                foundMatch = true;
                break;
            }
        }
        if (foundMatch)
        {
            wordsList.AddLast(LowercaseWord(words[i]));
        }
        else
        {
            wordsList.AddLast(CapitalizeWord(words[i]));
        }
    }
