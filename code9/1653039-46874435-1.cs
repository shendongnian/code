    // A dynamic pattern is given
    var pattern = @"[Date(m/d/y)], [time(nn:nn AM/PM)] - [name]: [message],";    
    var message = "9/15/17, 12:33 PM - Brian Bouman: Hey,";
    // in patternMaps; I make pattern conventions
    var patternMaps = new Dictionary<string, string>
                          {
                              { "[mdy]", @"\d\d?" },   -- I will replace `m`,`d`,`y`s between parentheses to accept one or two digits  
                              { "n", @"\d" },          -- I will replace `n`s between parentheses to accept one digit only
                              { @"AM/PM", "(AM|PM)" }, -- I will replace `AM/PM` between parentheses to accept `AM` or `PM`
                              { "[/]", @"\/" }         -- I will replace `/` between parentheses to `\/` for removing regex exception
                          };
    // `parts` contains name and patterns between `[` and `]`
    var parts =
        Regex.Matches(pattern, @"\[(?<part>[^(\]]+)(\((?<pattern>[^)]+)\))?]")
            .OfType<Match>()
            .ToDictionary(
                k => k.Groups["part"].ToString(),
                v => v.Groups["pattern"].ToString());
    // Applying patternMaps to patterns
    parts = patternMaps.Aggregate(
        parts,
        (current, pm) => current.ToDictionary(k => k.Key, v => Regex.Replace(v.Value, pm.Key, pm.Value)));
    // generate fit pattern for creating a proper regex
    var regexPattern = Regex.Replace(
        Regex.Replace(pattern, @"\([^)]+\)", string.Empty),
        @"\[(?<part>[^]]+)\]",
        c =>
            {
                var part = parts.SingleOrDefault(p => p.Key == c.Groups["part"].ToString());
                return string.IsNullOrWhiteSpace(part.Value) ? $@"(?<{part.Key}>[\w ]+)" : $@"(?<{part.Key}>{part.Value})";
            });
    // Applying generated pattern to message
    var result = Regex.Match(message, $"^{regexPattern}$");  // "^...$" means whole - from the beginning to the end pf - the string
    if (result.Success)
    {
        Console.WriteLine($"## Message matched##: {message}");
        foreach (var part in parts)
        {
            Console.WriteLine($"{part.Key}: {result.Groups[$"{part.Key}"]}");
        }
    }
    else
    {
        Console.WriteLine($"Message not matched!: {message}");
    }
