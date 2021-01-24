    var data = new Dictionary<int, List<int>>();
    data.Add(1, new List<int> { 0, 0, 0, 0, 0 });
    // continue filling the dictionary...
    var random = new Random();
    foreach (var entry in data)
    {
        entry.Value[random.Next(0, entry.Value.Count - 1)] = 1;
    }
    // print the results
    foreach (var entry in data)
    {
        Console.WriteLine("{0} => {1}", entry.Key, entry.Value.Join(", "));
    }
