    string sInput = @"LASTKNOWN:041A
    INVERT:041E
    INCOUNT:0422
    INZERO:042A
    OUTCOUNT:0434
    OUTZERO:043C";
    Regex r = new Regex(@"^(?<key>[^:]+):(?<val>.+)$", RegexOptions.Multiline);
    MatchCollection matches = r.Matches(sInput);
    Dictionary<String, String> lst = new Dictionary<string, string>();
    foreach (Match m in matches)
    {
        lst.Add(m.Groups["key"].Value, m.Groups["val"].Value);
    }
