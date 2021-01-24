    List<Test> testList = new List<Test>();
    // string, string, string = Property1, Property2, Property3
    var dict = new Dictionary<Tuple<string, string, string>, List<Test>>();
    foreach (var el in testList)
    {
        List<Test> list;
        var key = Tuple.Create(el.Property1, el.Property2, el.Property3);
        if (!dict.TryGetValue(key, out list))
        {
            list = new List<Test>();
            dict.Add(key, list);
        }
        list.Add(el);
    }
    var output = new List<Test>(dict.Count);
    foreach (var kv in dict)
    {
        var list = kv.Value;
        var el = new Test
        {
            Property1 = kv.Key.Item1,
            Property2 = kv.Key.Item2,
            Property3 = kv.Key.Item3,
            Property4 = list[0].Property4,
        };
        output.Add(el);
        for (int i = 0; i < list.Count; i++)
        {
            el.Property5 += list[i].Property5;
            el.Property6 += list[i].Property6;
            el.Property7 += list[i].Property7;
            el.Property8 += list[i].Property8;
        }
    }
