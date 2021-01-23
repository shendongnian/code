    string sInput = @"LASTKNOWN:041A
    INVERT:041E
    INCOUNT:0422
    INZERO:042A
    OUTCOUNT:0434
    OUTZERO:043C";
    System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"^(?<key>[^:]+):(?<val>.+)$", System.Text.RegularExpressions.RegexOptions.Multiline);
    System.Text.RegularExpressions.MatchCollection matches = r.Matches(sInput);
    string sValue = String.Empty;
    foreach (System.Text.RegularExpressions.Match m in matches)
    {
        if (String.Compare(m.Groups["key"].Value, "LASTKNOWN") == 0)
        {
            sValue = m.Groups["val"].Value;
        }
    }
