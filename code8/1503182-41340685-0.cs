    public bool CheckSentence(string messageText)
    {
        var count = 0;
        foreach (WordFilter Filter in this._filteredWords.ToList())
        {
           count += messageText.Split(' ').Count(x=> x == Filter.Word);            
        }
        return count >= 3;
    }
