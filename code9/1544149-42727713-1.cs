    public static string RepeatPattern(string pattern, int rows, int columns)
    {
        var patternSplitByLine = pattern.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    
        var oneColumnOutput = new List<string>();
        for (int i = 0, j = patternSplitByLine.Length; i<j; i++)
            oneColumnOutput.Add(string.Concat(Enumerable.Repeat(patternSplitByLine[i], columns)));
    
        var patternOneRowJoined = String.Join(Environment.NewLine, oneColumnOutput);
        var allRows = Enumerable.Repeat(patternOneRowJoined, rows);
    
        return String.Join(Environment.NewLine, allRows);
    }
