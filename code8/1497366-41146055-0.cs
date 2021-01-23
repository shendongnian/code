    var allLanguages = GetLanguages();
    var subset = SubsetOfLanguages
        .Where(lg => allLanguages.Any(a => lg.IdLanguage == a.IdLanguage))
        .ToArray();
    foreach(var item in subset)
    {
        item.HaveLanguage = True;
    }
