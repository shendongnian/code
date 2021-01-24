    var counter = new Dictionary<int, Dictionary<string, int>>();
    foreach (var i in Enumerable.Range(1,21))
    {
        counter.Add(i, new Dictionary<string, int>());
    }
