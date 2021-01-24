    var groups = allSValues.GroupBy(
        s => start.Where(dictionary => dictionary.Value.Contains(s)),
        (dictionaries, sValues) => new {
            S = sValues.Single(),
            PValues = dictionaries.Select(kvp => kvp.Key)
        });
