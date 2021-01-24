    foreach(var item1 in list1)
    {
        if(list2.Any(item2=>item2.Id== item1.Id))
        {
            //do nothing
            continue;
        }
        // do something
    }
