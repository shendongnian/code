        var dict = new Dictionary<Tuple<string,int>, int>();
        dict.Add(Tuple.Create("a", 123), 19);
        dict.Add(Tuple.Create("a", 456), 12);
        dict.Add(Tuple.Create("a", 789), 13);
        dict.Add(Tuple.Create("b", 998), 99);
        dict.Add(Tuple.Create("b", 999), 11);
        var d = dict.aggregateBy(p => p.Key.Item1, p => p.Value, Math.Min);
        Debug.Print(string.Join(", ", d));        // "[a, 12], [b, 11]"
