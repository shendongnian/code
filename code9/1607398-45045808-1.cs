    int statusCode = 0;
    string output = 'QLASR: Bad Response Conflict StatusCode: 409, ...'
    string pattern = @"StatusCode\:\s?(\d+)";
    Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
    Match m = r.Match(output);
    if (m.Success)
    {
         statusCode = (int)m.Groups[1].Value;
         Debug.WriteLine(statusCode);
    }
