    private static IEnumerable<string> Filter(string input)
    {
        var subWords = input.Split('.');
        bool skip = false;
    
        foreach (var word in subWords)
        {
            if (skip)
            {
                skip = false;
            }
            else
            {
                yield return word;
            }
            if (word.EndsWith("[]"))
            {
                skip = true;
            }
        }
    }
