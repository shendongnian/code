    Dictionary<string, List<int>> allLists = new Dictionary<string, List<int>>();
    
    allLists.Add("list_1", list_1);
    allLists.Add("list_2", list_2);
    allLists.Add("list_3", list_3);
    allLists.Add("list_4", list_4);
    
    string logRes = String.Join(" ", allLists
        .Where(x => x.Value.Count < 300)
        .Select(x => String.Format("Name: {0} Amount: {1}", x.Key, x.Value.Count)));
