    public bool CheckSentence(string messageText)
    {
        var count = 0;
        string[] wordsInMessage = messageText.Split(new char[]{' ',','}, StringSplitOptions.RemoveEmptyEntries);
        foreach (WordFilter Filter in this._filteredWords.ToList())
        {
           count += wordsInMessage.Count(x=> x == Filter.Word);            
        }
        return count >= 3;
    }
