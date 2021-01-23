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
        // in case if word doesn't have empty positions
        if (emptyIndexes.Count == 0)
        {
            return wordToProcess;
        }
    
        Random random = new Random();
        var indexForLetter = random.Next(emptyIndexes.Count);
    
        // create stringBuilder from string, because string is immutable and you can't change separate symbol
        StringBuilder sb = new StringBuilder(wordToProcess); 
        // insert symbol from originalWord in empty previously generated position
        sb[emptyIndexes[indexForLetter]] = originalWord[emptyIndexes[indexForLetter]]; // 
    
        //convert stringBuilder to string and return
        return sb.ToString();
    }
