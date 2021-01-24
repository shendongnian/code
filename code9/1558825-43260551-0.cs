    private static string ProcessHeadersInText(string inputText, int atLevel = 1)
    {
        // Group 1 = value after 'h'
        // Group 2 = Content of header without leading whitespace
        string pattern = @"^h(\d+)\.\s*(.*)$";
        return Regex.Replace(inputText, pattern, match => EvaluateHeaderMatch(match, atLevel), RegexOptions.Multiline);
    }
    private static string EvaluateHeaderMatch(Match m, int atLevel)
    {
        int hVal = int.Parse(m.Groups[1].Value) + atLevel;
        if (hVal > 9) { hVal = 9; }
        return $"<h{hVal}>{m.Groups[2].Value}</h{hVal}>";
    }
