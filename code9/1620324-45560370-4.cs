    using System.Text.RegularExpressions;
    ...
    Regex rx = new Regex(@"\[\s*((?<word>[^[\]\s]+)\s*)+]");
    MatchCollection matches = rx.Matches(searchText);
    foreach(Match m in matches) {
        foreach(Capture c in m.Groups["word"].Captures) {
            System.Console.WriteLine(c.Value);
        }
    }
