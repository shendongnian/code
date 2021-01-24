    SortedList<int,string> list = new SortedList<int, string>();
    
    list.Add(1, "name1");
    list.Add(2, "name2");;
    
    var c = list.Select(x => x.Value == "name2").FirstOrDefault();
