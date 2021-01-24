    public static IEnumerable<Tuple<int,int>> GetHighlights(string expression, string search)
    {
        var highlights = new List<Tuple<string, int, int>>();
    
        var wordsToHighlight = new Regex(@"(\w+|[^\s]+)").
            Matches(search).
            Cast<Match>().
            Select(x => x.Value);
    
        foreach(var wordToHighlight in wordsToHighlight)
        {
            Regex findMatchRegex = null;
            if (new Regex(@"\W").IsMatch(wordToHighlight))
                findMatchRegex = new Regex(String.Format(@"({0})", wordToHighlight), RegexOptions.IgnoreCase);  // is punctuation
            else
                findMatchRegex = new Regex(String.Format(@"((?<!\w){0}(?!\w))", wordToHighlight), RegexOptions.IgnoreCase); // si word
                    
            var matches = findMatchRegex.Matches(expression).Cast<Match>().Select(match => new Tuple<string, int, int>(wordToHighlight, match.Index, match.Index + wordToHighlight.Length));
    
            if (matches.Any())
                highlights.AddRange(matches);
            else
                return new List<Tuple<int, int>>();
        }
                
        // Reduce the scope of the highlights in order to 
        // keep the indexes as together as possible.
        var firstWord = wordsToHighlight.First();
        var firstWordIndex = highlights.IndexOf(highlights.Last(x => String.Equals(x.Item1, firstWord)));
    
        var lastWord = wordsToHighlight.Last();
        var lastWordIndex = highlights.IndexOf(highlights.Last(x => String.Equals(x.Item1, lastWord)));
    
        var sanitizedHighlights = highlights.SkipWhile((x, i) => i < firstWordIndex);
        sanitizedHighlights = sanitizedHighlights.TakeWhile((x, i) => i <= lastWordIndex);
    
        highlights = new List<Tuple<string, int, int>>();
        foreach (var word in wordsToHighlight.Reverse())
        {
            var lastOccurence = sanitizedHighlights.Last((x) => String.Equals(x.Item1, word));
            sanitizedHighlights = sanitizedHighlights.TakeWhile(x => x.Item3 < lastOccurence.Item2);
            highlights.Add(lastOccurence);
        }
    
        highlights.Reverse();
    
        return highlights.Select(x => new Tuple<int, int>(x.Item2, x.Item3));
    }
