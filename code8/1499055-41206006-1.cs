    string sInput = @"LASTKNOWN:041A
    INVERT:041E
    INCOUNT:0422
    INZERO:042A
    OUTCOUNT:0434
    OUTZERO:043C";
    System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"^LASTKNOWN:(?<val>.+)$", System.Text.RegularExpressions.RegexOptions.Multiline);
    System.Text.RegularExpressions.Match m = r.Match(sInput);
    string sValue = String.Empty;
    if (m.Success)
        sValue = m.Value;
