    string pattern = @"^.+ (\d+)$";
    string input = "Testing stackoverflow 6789";
    var match = Regex.Match(input, pattern, RegexOptions.None, new TimeSpan(0, 0, 0, 0, 500));
    int? output;
    if (match != null)
    {
        string groupValue = match.Groups[1].Value;
        output = Convert.ToInt32(groupValue); 
    }
