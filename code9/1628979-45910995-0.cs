    var allData = new Dictionary<string, List<int>>();
    allData["Bob"] = new List<int>() { 1 , 2 , 3 };
    var allInts = allData.Values.SelectMany(m => m); // IEnumerable<int>
    var intsByName = allData["nameToSelect"]; // List<int>
    var availableNames = allData.Keys;
