    var russianSmall = Enumerable.Range(0x0430, 32)
        .Concat(new[] { 0x0451 })
        .Select(i => Convert.ToChar(i))
        .ToList();
    var russianSmallOrdered = russianSmall
        .OrderBy(c => c.ToString(), StringComparer.Create(new CultureInfo("ru-RU"), false))
        .ToList();
    var russianCapital = Enumerable.Range(0x410, 32)
        .Concat(new[] { 0x0401 })
        .Select(i => Convert.ToChar(i))
        .ToList();
    var russianCapitalOrdered = russianCapital
        .OrderBy(c => c.ToString(), StringComparer.Create(new CultureInfo("ru-RU"), false))
        .ToList();
