    List<Test> testList = new List<Test>();
    // string, string, string = Property1, Property2, Property3
    var dict = new Dictionary<Tuple<string, string, string>, Test>();
    foreach (var el in testList)
    {
        Test el2;
        var key = Tuple.Create(el.Property1, el.Property2, el.Property3);
        if (!dict.TryGetValue(key, out el2))
        {
            el2 = new Test
            {
                Property1 = el.Property1,
                Property2 = el.Property2,
                Property3 = el.Property3,
                Property4 = el.Property4,
            };
            dict.Add(key, el2);
        }
        el2.Property5 += el.Property5;
        el2.Property6 += el.Property6;
        el2.Property7 += el.Property7;
        el2.Property8 += el.Property8;
    }
    var output = dict.Values.ToList();
