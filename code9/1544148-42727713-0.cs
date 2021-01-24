    public static string RepeatPattern(string pattern, int rows, int columns)
    {
        var patternSplitByLine = pattern.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    
        var oneColumnOutput = new List<string>();
        for (int i = 0, j = patternSplitByLine.Length; i<j; i++)
        {
            var currentRow = new List<string>();
            for (int c = 0; c < columns; c++)
            {
                currentRow.Add(patternSplitByLine[i]);
            }
    
            oneColumnOutput.Add(String.Join(String.Empty, currentRow));
        }
    
        var patternOneRowJoined = String.Join(Environment.NewLine, oneColumnOutput);
        var allRows = Enumerable.Repeat(patternOneRowJoined, rows);
    
        return String.Join(Environment.NewLine, allRows);
    }
