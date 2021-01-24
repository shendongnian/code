    var result = allSValues.Select(s => new {
            S = s,
            PValues = start
                .Where(dictionary => dictionary.Value.Contains(s))
                .Select(kvp => kvp.Key)
        });
