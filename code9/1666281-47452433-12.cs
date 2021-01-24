    var lookup = allSValues.Select(s => new
        {
            S = s,
            PValues = start
                .Where(kvp => kvp.Value.Contains(s))
                .Select(kvp => kvp.Key)
                .ToList()
        })
        .ToLookup(item => item.PValues, item => item.S, new SequenceEqualityComparer());
