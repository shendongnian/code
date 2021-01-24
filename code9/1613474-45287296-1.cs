    public static IEnumerable<int> GenerateRandom()
    {
        var random = new Random();
        while(true) { yield return random.Next() }
    }
    // Later...
    var newValues = MyClass.GenerateRandom()
        .Where(next => !currentNumbers.Contains(next))
        .Distinct()
        .Take(amount)
        .ToList();
