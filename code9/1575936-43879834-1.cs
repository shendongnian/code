    var mySortedDictionary = new SortedDictionary<string, List<int>>
    {
        {"orange", new List<int> {2, 9}},
        {"money", new List<int> {2, 4, 8, 9}},
        {"monkey", new List<int> {2, 4, 9}},
        {"hokey", new List<int> {2, 5, 9}}
    };
    foreach (var item in mySortedDictionary.OrderBy(item => item.Value.Count))
    {
        Console.WriteLine($"{item.Key} {string.Join(", ", item.Value)}");
    }
