    var listOfLists = new List<List<string>>();
    
    // Setup test data
    for (int i = 0; i < 10; i++)
    {
        listOfLists.Add(Enumerable.Range(0, 10000).Select(z => z.ToString()).ToList());
    }
    
    // Pre-allocate Capacity here - this will have the most benefit for listOfLists consisting of a small number of large lists
    var capacity = 0;
    for (int i = 0; i < listOfLists.Count; i++)
        capacity += listOfLists[i].Count;
    List<string> result = new List<string>(capacity);
    
    for (int i = 0; i < listOfLists.Count; i++) // changed to for loop based on Tommaso's advice
    {
        result.AddRange(listOfLists[i]); // AddRange is faster than Add - https://stackoverflow.com/a/9836512/34092
    }
