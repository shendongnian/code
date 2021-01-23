    public string GetWordAfterHint(string wordToProcess, string originalWord)
    {
        List<int> emptyIndexes = new List<int>();
        for (int a = 0; a < wordToProcess.Length; a++)
        {
            if (wordToProcess[a] == '_')
            {
                emptyIndexes.Add(a);
            }
        }
    
        Random random = new Random();
        var indexForLetter = random.Next(emptyIndexes.Count);
    
        StringBuilder sb = new StringBuilder(wordToProcess);
        sb[emptyIndexes[indexForLetter]] = originalWord[emptyIndexes[indexForLetter]];
    
        return sb.ToString();
    }
