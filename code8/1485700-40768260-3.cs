    Regex r = new Regex(@"get\s*?
                            ^(\s+){
                            [\s\S]*?
                            ^\1}", RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
    var matches = r.Matches(input);
    foreach(Match m in matches)
    {
        Console.WriteLine(Regex.Replace(m.Value, "^" + m.Groups[1].Value, "", RegexOptions.Multiline));
    }
