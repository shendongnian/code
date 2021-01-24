    public static IEnumerable<Tuple<int, int>> GetHighlights(string input, IEnumerable<string> searchExpression)
    {
        var highlights = new List<Tuple<int, int>>();
    
        var lastMatchedIndex = 0;
        foreach (var word in searchExpression)
        {
            var indexOfWord = input.IndexOf(word, lastMatchedIndex,  StringComparison.CurrentCulture);
            var lastIndexOfWord = indexOfWord + word.Length;
    
            highlights.Add(new Tuple<int, int>(indexOfWord, lastIndexOfWord));
    
            lastMatchedIndex = lastIndexOfWord;
        }
    
        // If the entire expression is not 
        // matched, return empty highlights.
        if(highlights.Count() == searchExpression.Count())
            return highlights;
        else
            return new List<Tuple<int, int>>();
    }
