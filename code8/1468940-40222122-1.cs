    string text = File.ReadAllText("customers.txt");
    string pattern = @"(?<= ^ \*) .+? (?= \* \r? $)";
    var options = RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled
        | RegexOptions.Singleline | RegexOptions.Multiline;
    var matches = Regex.Matches(text, pattern, options);
    for (int i = 0; i < matches.Count; i += 5)
    {
        var customer = new Customer
        {
            Name = matches[i].Value,
            LastJobDescription = matches[i + 1].Value,
            JobCodes = matches[i + 2].Value.Split().Select(s => int.Parse(s)).ToList(),
            JobAddress = matches[i + 3].Value,
            Comments = matches[i + 4].Value
        };
        customers.Add(customer);
    }
