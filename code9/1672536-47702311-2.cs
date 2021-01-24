    public static TimeSpan ParseTwitchTime(string input)
    {
        var m = Regex.Match(input, @"^((?<hours>\d+)h)?((?<minutes>\d+)m)?((?<seconds>\d+)s)?$", RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        
        int hs = m.Groups["hours"].Success ? int.Parse(m.Groups["hours"].Value) : 0;
        int ms = m.Groups["minutes"].Success ? int.Parse(m.Groups["minutes"].Value) : 0;
        int ss = m.Groups["seconds"].Success ? int.Parse(m.Groups["seconds"].Value) : 0;
        return TimeSpan.FromSeconds(hs*60*60 + ms*60 + ss);
    }
