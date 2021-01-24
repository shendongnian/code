    static void Main(string[] args)
    {
        var input = "Since there is limited overhead space on the plane, I assure you, there will be no fee for checking the bags, I can go ahead and fill out all the checked baggage forms for you";
        var searchExpression = "no fee, I fill out the forms";
    
        var highlightedInput = HighlightString(input, searchExpression, "<b>", "</b>");
                
        Console.WriteLine(highlightedInput);
        Console.ReadLine();
    }
            
    public static IEnumerable<Tuple<int, int>> GetHighlights(string input, string searchExpression)
    {
        var splitIntoWordsRegex = new Regex(@"\W+");
        var words = splitIntoWordsRegex.Split(searchExpression);
        return GetHighlights(input, words);
    }
    
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
    
        return highlights;
    }
    
    public static string HighlightString(string input, string searchExpression, string highlightPrefix, string highlightSufix)
    {
        var highlights = GetHighlights(input, searchExpression).ToList();
                
        var output = input;
        for (int i = 0, j = highlights.Count; i<j; i++)
        {
            int diffInputOutput = output.Length - input.Length;
            output = output.Insert(highlights[i].Item1 + diffInputOutput, highlightPrefix);
    
            diffInputOutput = output.Length - input.Length;
            output = output.Insert(highlights[i].Item2 + diffInputOutput, highlightSufix);
        }
    
        return output;
    }
