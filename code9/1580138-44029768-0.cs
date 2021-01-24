    public void FormatFile(string sourcePath, string targetPath)
    {
        IEnumerable<String> originalContent = GetFileLines(sourcePath);
        IEnumerable<String> formatedContent = ProcessFileLines(originalContent);
        OutputResults(targetPath, formatedContent);
    }
    public IEnumerable<String> GetFileLines(string path) {
        return File.ReadLines(path);
    }
    public IEnumerable<string> ProcessFileLines(IEnumerable<string> fileLines)
    {        
        return processedLines.Select(l => ProcessLine(l)
                             .Where(l => !string.IsNullOrEmpty(l))
                             .GetRange(0, MAX_LINE_COUNT);
    }
    public string ProcessLine(string fileLine)
    {
        string s = fileLine.Substring(0, 5);
        if (s.Equals("BRUSH", StringComparison.InvariantCultureIgnoreCase)
            return string.Empty;
        return fileLine;
    }
    public void OutputResults(string targetPath, IEnumerable<string> fileLines)
    {
            string outputText = fileLines.Join($",{Environment.NewLine}");
            File.WriteAllText(targetPath, outputText);
    }
