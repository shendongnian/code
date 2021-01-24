    var pattern = @"[Date(m/d/y)], [time(nn:nn AM/PM)] - [name]: [message],";
    var message = "9/15/17, 12:33 PM - Brian Bouman: Hey,";
    // in patternMaps; I make your pattern conventions
    var patternMaps = new Dictionary<string, string>
                          {
                              { "[mdy]", @"\d\d?" },
                              { "n", @"\d" },
                              { @"AM/PM", "(AM|PM)" },
                              { "[/]", @"\/" }
                          };
    var parts =
        Regex.Matches(pattern, @"\[(?<part>[^(\]]+)(\((?<pattern>[^)]+)\))?]")
            .OfType<Match>()
            .ToDictionary(
                k => k.Groups["part"].ToString(),
                v => v.Groups["pattern"].ToString());
    parts = patternMaps.Aggregate(
        parts,
        (current, pm) => current.ToDictionary(k => k.Key, v => Regex.Replace(v.Value, pm.Key, pm.Value)));
    var regexPattern = Regex.Replace(
        Regex.Replace(pattern, @"\([^)]+\)", string.Empty),
        @"\[(?<part>[^]]+)\]",
        c =>
            {
                var part = parts.SingleOrDefault(p => p.Key == c.Groups["part"].ToString());
                return string.IsNullOrWhiteSpace(part.Value) ? $@"(?<{part.Key}>[\w ]+)" : $@"(?<{part.Key}>{part.Value})";
            });
    var result = Regex.Match(message, $"^{regexPattern}$");
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
