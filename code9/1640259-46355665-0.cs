	var list1 = new List<string> { "B", "S", "", "", "", "", "" };
    var list2 = new List<string> { "", "", "B", "S", "", "", "" };
    var list3 = new List<string> { "", "", "", "", "B", "S", "" };
    var list4 = new List<string>();
    
    for (int i = 0; i < list1.Count; i++)
    {
        if (!string.IsNullOrWhiteSpace(list1[i]))
            list4.Add(list1[i]);
        else if (!string.IsNullOrWhiteSpace(list2[i]))
            list4.Add(list2[i]);
        else
            list4.Add(list3[i]);
    }
