    string pattern = @"(Band) (?<Band>[A-Za-z ]+) (?<City>@[A-Za-z ]+) (?<Price>\d+) (?<Quantity>\d+)";
    string input = "Band Name @City 25 3500";
    MatchCollection match = Regex.Matches(input, pattern);
    
    foreach(Match m in match)
    {
        Console.WriteLine(m.Groups["Band"].Value);
        Console.WriteLine(m.Groups["City"].Value.TrimStart('@'));
        Console.WriteLine(m.Groups["Price"].Value);
        Console.WriteLine(m.Groups["Quantity"].Value);
    }
