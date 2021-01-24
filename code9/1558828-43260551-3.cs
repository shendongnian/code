    public static string ProcessHeadersInText(string inputText, int atLevel = 1)
    {
        string pattern = @"^h(\d+)\.\s*(.*?)\r?$";
        return Regex.Replace(inputText, pattern,
            match =>
            {
                int hVal = int.Parse(match.Groups[1].Value) + atLevel;
                if (hVal > 9) { hVal = 9; }
                return $"<h{hVal}>{match.Groups[2].Value}</h{hVal}>";
            },
            RegexOptions.Multiline);
    }
