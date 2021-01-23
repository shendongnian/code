    IEnumerable<IEnumerable<object>> data = Enumerable.Repeat(new List<object> { 10, "Twenty", 30, 40, DateTime.UtcNow }, int.MaxValue);
    var hashSet = new HashSet<string>();
    var result = data.Select((enumerable, index) =>
    {
        var list = (List<object>)enumerable;
        if (index > 0) list[0] = null; // only 1 value
        // unique
        string str = (string)list[1];
        if (hashSet.Contains(str))
            list[1] = null;
        else
            hashSet.Add(str);
        list[2] = null; // disabled
        return list;
    });
    Console.WriteLine(result.Count());
