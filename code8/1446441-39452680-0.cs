    var list1 = new List<int>();
    var list2 = new List<string>();
    var list3 = new List<double>();
    IList[] allLists = {list1, list2, list3};
    bool result = allLists.All(l => l.Count == allLists[0].Count);
