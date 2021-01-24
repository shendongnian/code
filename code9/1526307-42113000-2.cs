    var resultDictionary = new ConcurrentDictionary<double, Dictionary<DateTime, double>>();
    // Use For-Loop index as Key
    Parallel.ForEach(input, (item, state, index) => {
        resultDictionary.TryAdd(index, SomeDataDictionary(item));
    });
    // Convert the dictionary to a list in the required order
    var resultList = resultDictionary.Keys.OrderBy(k => k).Select(k => resultDictionary[k]).ToList();
