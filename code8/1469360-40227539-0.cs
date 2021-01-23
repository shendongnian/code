    string pattern = @"^Testing stackoverflow (\d+)$";
    string input = "Testing stackoverflow 6789";
    var match = Regex.Match(input, pattern);
    int? output;
    if (match != null)
    {
        string groupValue = match.Groups[1].Value;
        output = Convert.ToInt32(groupValue); 
    }
