    Dictionary<string, int> points = new Dictionary<string, int>
    {
        { "Ali", 1111},
        { "Hasan", 2222},
        { "HoseynJan", 3333 }
    };
    
    string json = JsonConvert.SerializeObject(points, Formatting.Indented);
    
    Console.WriteLine(json);
    // {
    //   "Ali": 1111,
    //   "Hasan": 2222,
    //   "HoseynJan": 3333
    // }
