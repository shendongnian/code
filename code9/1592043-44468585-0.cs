    Dictionary<int, List<string>> group = new Dictionary<int, List<string>>();
    List<string> newList = new List<string> { "Orange", "Strawberry", "Banana"};
    group.Add(1, newList); //Group of Fruits
    
    newList = new List<string> { "Hulk", "Spiderman", "Batman" };
    group.Add(2, newList); //Group of Super-Heroes
    int GroupKey = 0;
    foreach(var groupItem in group)
    {
	    foreach(var stringValue in groupItem.Value)
	    {
		    if(stringValue == "Spiderman")
		    {
			    GroupKey = groupItem.Key;
			    break;
		    }
	    } 
        if(GroupKey > 0)
            break
    }
