    var test = new SortedBiDcit<object, string>();
    test.Add(new object(), "test");
    for (int i = 0; i < test.Count; ++i)
    {
        var tuple = test[i];
        var str = test[tuple.Item1]; //retrieve T2
        var obj = test[tuple.Item2]; //retrieve T1
        Console.WriteLine(tuple.Item2); //prints "test"
    }
