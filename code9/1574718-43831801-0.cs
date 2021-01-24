       var abc= Regex.Matches("co12dEname123abP", @"[a-zA-Z]+|\d+")
    .Cast<Match>()
    .Select(m => m.Value)
    .ToArray();
        List<string> lst = new List<string>();
        for (int i = 0; i < abc.Length; i++)
        {
            if (abc[i].Any(char.IsDigit))
                continue;
            if (abc[i].Any(c => char.IsUpper(c)))
                lst.Add(abc[i]);
        }
        var finalOutput =lst.OrderByDescending(x => x.Length).FirstOrDefault();
