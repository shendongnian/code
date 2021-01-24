    List<Item> groupedList = new List<Item>();
    
    int groupId = 1;
    foreach (var group in grp)
    {
        int id = group.Count() > 1 ? groupId++ : 0;
    
        // Loop through each item within group
        foreach (var item in group)
        {
            item.GroupID = id;
            groupedList.add(Item);
        }
    }
    
    myDestList = groupedList;
