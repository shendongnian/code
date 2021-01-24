    public static IEnumerable<string> SeparateNumbers(string inputText)
    {
        var matches = Regex.Matches(inputText, "[0-9]{12}");
    
        foreach (Match match in matches)
        {
            yield return inputText.Substring(match.Index, match.Length);
        }
    }
