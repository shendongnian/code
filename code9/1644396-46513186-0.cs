    var dictPretendedMostRecentVersionsByDetails = ServerCollection
        .GroupBy(entry => AssembleKey(entry))
        .ToDictionary(
            group => group.Key, 
            group => group.Value
                .OrderByDescending(entry => Version.Parse(entry.version))
                .First()
        );
