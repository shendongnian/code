    var set = GenerateTwoElementSet(4);
    foreach (var tuple in set)
    {
        Console.WriteLine("{" + tuple.Item1 + "," + tuple.Item2 +"}");
    }
    // Outputs the following:
    // {1,2}
    // {1,3}
    // {1,4}
    // {2,3}
    // {2,4}
    // {3,4}
