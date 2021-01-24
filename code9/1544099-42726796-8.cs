    public static IEnumerable<Tuple<int, int>> GetHighlights(string input, IEnumerable<string> searchExpression)
    {
        var highlights = new List<Tuple<string, int, int>>();
    
        // Finds all the indexes for 
        // all the words found.
        foreach (var word in searchExpression)
        {
            var allIndexesOfWord = AllIndexesOf(input, word, StringComparison.InvariantCultureIgnoreCase);
            highlights.AddRange(allIndexesOfWord.Select(index => new Tuple<string, int, int>(word, index, index + word.Length)));
        }
    
        // Reduce the scope of the highlights in order to 
        // keep the indexes as together as possible.
        var firstWord = searchExpression.First();
        var firstWordIndex = highlights.IndexOf(highlights.Last(x => String.Equals(x.Item1, firstWord)));
    
        var lastWord = searchExpression.Last();
        var lastWordIndex = highlights.IndexOf(highlights.Last(x => String.Equals(x.Item1, lastWord)));
                
        var sanitizedHighlights = highlights.SkipWhile((x, i) => i < firstWordIndex);
        sanitizedHighlights = sanitizedHighlights.TakeWhile((x, i) => i <= lastWordIndex);
    
        highlights = new List<Tuple<string, int, int>>();
        foreach (var word in searchExpression.Reverse())
        {
            var lastOccurence = sanitizedHighlights.Last((x) => String.Equals(x.Item1, word));
            sanitizedHighlights = sanitizedHighlights.TakeWhile(x => x.Item3 < lastOccurence.Item2);
            highlights.Add(lastOccurence);
        }
    
        highlights.Reverse();
    
        return highlights.Select(x => new Tuple<int, int>(x.Item2, x.Item3));
    }
    
    public static List<int> AllIndexesOf(string str, string value, StringComparison comparison)
    {
        if (String.IsNullOrEmpty(value))
            throw new ArgumentException("the string to find may not be empty", "value");
    
        List<int> indexes = new List<int>();
        for (int index = 0; ; index += value.Length)
        {
            index = str.IndexOf(value, index, comparison);
            if (index == -1)
                return indexes;
            indexes.Add(index);
        }
    }
