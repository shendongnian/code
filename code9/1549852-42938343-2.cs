    var indexPositions = new Dictionary<string, int> {
        { "KK", 0 },
        { "AB", 1 },
        { "BC", 2 },
        { "DD", 3 },
        { "FV", 4 },
        { "ER", 5 },
        { "PP", 6 },
        { "WW", 7 }
    }
    foreach (var package in mail.Package)
    {   // access position
        int index;
        if (!indexPositions.TryGetValue(a.Name, out index)) {
            throw new KeyNotFoundException()
        }
        list[index] = package;
    }
