    List<List<object>> lists = new List<List<object>>();
        lists.Add(new List<object> { "zxc", 0.1, 3 });
        lists.Add(new List<object> { "dfg", 0.3, 7 });
        lists.Add(new List<object> { "abc", 0.8, 3 });
        lists.Add(new List<object> { "fhc", 1.7, 8 });
        lists.Add(new List<object> { "ghr", 5.5, 9 });
    var result = lists.Where(o => (double)o[1] > 1).ToList();
