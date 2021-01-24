    string blah = @"<ul>
    <li>foo</li>
    <li>bar</li>
    <li>oof</li>
    </ul>";
    string liRegexString = @"(?:.)*?<li>(.*?)<\/li>(?:.?)*";
    Regex liRegex = new Regex(liRegexString, RegexOptions.Multiline);
    MatchCollection liMatches = liRegex.Matches(blah);
    foreach (var match in liMatches.Cast<Match>())
    {
        Console.WriteLine(match.Groups[1]);
    }
