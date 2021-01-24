    using System.Text.RegularExpressions;
    
    string InfoParse(string input, string word)
    {
        Match m = Regex.Match(input, @"\s?(?<LastBefore>\w+)\s+" + word, RegexOptions.Singleline);
        if (m.Success)
            return m.Groups["LastBefore"].Value;
        return null;
    }
