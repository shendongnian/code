    ViewDataDictionary vd = new ViewDataDictionary();
    List<string> lst = new List<string>();
    lst.Add("Data1User1");
    lst.Add("Data2User1");
    lst.Add("Data3User1");
    lst.Add("Data4User1");
    vd.Add("User1", lst);
    
    lst = new List<string>();
    lst.Add("Data1User2");
    lst.Add("Data2User2");
    vd.Add("User2", lst);
    ViewData["vdt"] = vd;
