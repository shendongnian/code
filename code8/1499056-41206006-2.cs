    string sInput = @"LASTKNOWN:041A
    INVERT:041E
    INCOUNT:0422
    INZERO:042A
    OUTCOUNT:0434
    OUTZERO:043C";
    Regex r = new Regex(@"^(?<key>[^:]+):(?<val>.+)$", RegexOptions.Multiline);
    MatchCollection matches = r.Matches(sInput);
    string sValue = String.Empty;
    foreach (Match m in matches)
    {
        if (String.Compare(m.Groups["key"].Value, "LASTKNOWN") == 0)
        {
            sValue = m.Groups["val"].Value;
        }
    }
