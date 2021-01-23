	List<string> list = new List<string>(10);
	int curIndex = -1;
	void DoTest()
	{
        //assume we fill 10 items in list 
		for (int i = 0; i < 10; i++)
		{
			AddListItem("item" + i);
		}
        
		AddListItem("new item A"); //this will override first item
		AddListItem("new item B"); //this will override second item
        // Now list contains these items:
        // [0] => new item A
        // [1] => new item B
        // [2] .. [N] => older items
	}
	void AddListItem(string value)
	{
		curIndex++; if (curIndex >= 10) curIndex = 0;
		if (curIndex >= list.Count)  
			list.Add(value);  
		else 
			list[curIndex] = value;
	}
