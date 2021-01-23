    var p1 = LocalTimePattern.ExtendedIsoPattern;
    var p2 = LocalTimePattern.CreateWithInvariantCulture("HH:mm");
    // formatting
    LocalTime t = // your input
    var p = t.Second == 0 && t.TickOfSecond == 0 ? p2 : p1;
    string s = t.Format(p);
    // parsing
    string s = // your input
    var result = p1.Parse(s);
    if (!result.Success)
        result = p2.Parse(s);
    if (!result.Success)
        // throw some exception, etc.
    LocalTime t = result.Value;
    
