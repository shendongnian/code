    var allInts = allData
        .Select(m => m.someData); // IEnumerable<int>
    var intsByName = allData
        .Where(m => m.name.Equals("nameToSelect"))
        .Select(m => m.someData); // IEnumerable<int>
    var availableNames = allData.Select(m => m.name).Distinct();
    
