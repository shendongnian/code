    static IEnumerable<Range> ParseOfferDateRanges(string input)
    {
        var matches = Regex.Matches(input, @"offerDate\((\d+),(\d+)?\)");
        return matches
            .Cast<Match>()
            .Select(ParseOfferDateMatch)
            .ToList();
    }
    static Range ParseOfferDateMatch(Match match)
    {
        var fromValue = match.Groups[1].Value;
        var toGroup = match.Groups[2];
        var to = toGroup.Success
            ? short.Parse(toGroup.Value)
            : (short?)null;
        return new Range()
        {
            From = short.Parse(fromValue),
            To = short.Parse(toValue)
        };
    }
