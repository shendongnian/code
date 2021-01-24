    // See how many lines we need to add
    var newLinesNeeded = 100 - File.ReadAllLines(AccountsFile).Length;
    // Add them if needed
    if (newLinesNeeded > 0)            
    {
        // Create a list of empty lines
        var blankLines = new List<string>();
        for(int i = 0; i < newLinesNeeded; i++)
        {
            blankLines.Add("");
        }
        // Append them to our file
        File.AppendAllLines(AccountsFile, blankLines);
    }
