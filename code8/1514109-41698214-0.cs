    internal static TimeSpan ParseSpecialTimespan(string toParse)
    {
        string pattern = @"^(\d+):([0-5]?\d{1}):([0-5]?\d{1})$";
        var match = Regex.Match(toParse, pattern);
        if (!match.Success) throw new ArgumentException(@"The provided string is not valid...");
        int hours = int.Parse(match.Groups[1].ToString());
        int minutes = int.Parse(match.Groups[2].ToString());
        int seconds = int.Parse(match.Groups[3].ToString());
        TimeSpan t = new TimeSpan(hours, minutes, seconds);
        return t;
    }
