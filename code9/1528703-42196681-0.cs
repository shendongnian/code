    // Don't forget to escape full-stops!
    Regex regex = new Regex( @"RESPONSIVE\.constant\.user = {(?<userParams>.*?)}", RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.Singleline);
    Match match = regex.Match(pageSourceCode);
    if (match.Success)
    {
        // Split up the values using comma
        var keyValuePairs = match.Groups["userParams"].Value.Split(',');
        // Split up each line using : as delimeter and clean up both sides, removing whitespace and single quote characters
        var dict = keyValuePairs
            .Select(kvp => kvp.Split(':'))
            .ToDictionary(kvp => kvp[0].Trim(), kvp => kvp[1].Trim().Trim(new char[] { '\'' }));
        // Read name
        var name = dict["name"];
    }
