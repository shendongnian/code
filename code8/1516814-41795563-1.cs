    Dictionary<long, List<string>> myDic = new Dictionary<long, List<string>>();
    long myNewKey = 1;
    List<string> list;
    if (!myDic.TryGetValue(myNewKey, out list))
    {
        list = new List<string>();
        myDic.Add(myNewKey, list);
    }
    
    list.Add("string01");
    list.Add("string02");
