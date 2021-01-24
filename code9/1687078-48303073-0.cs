    PairList pairs = new PairList();
    pairs.Add(Tuple.Create(1, 2));
    pairs.Add(Tuple.Create(3, 4));
    pairs.Add(Tuple.Create(3, 5));
    pairs.Add(Tuple.Create(5, 6));
    pairs.Add(Tuple.Create(10, 11));
    pairs.Add(Tuple.Create(2, 3));
    Console.WriteLine("Result:");
    foreach(List<int> list in pairs)
        Console.WriteLine(string.Join(",", list));
    // Output:
    // Result:
    // 1,2,3,4,5,6
    // 10,11
