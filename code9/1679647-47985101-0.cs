    var listOfLists = new List<List<string>>();
    
    // Setup test data
    for (int i = 0; i < 10; i++)
    {
        listOfLists.Add(Enumerable.Range(0, 10000).Select(z => z.ToString()).ToList());
    }
    
    // Pre-allocate Capacity here - this will have the most benefit of listOfLists consists of a small number of large lists
    List<string> result = new List<string>(listOfLists.Sum(z => z.Count));
    
    foreach (List<string> list in listOfLists)
    {
        result.AddRange(list); // AddRange is faster than Add - https://stackoverflow.com/a/9836512/34092
    }
