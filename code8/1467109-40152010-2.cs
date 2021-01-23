	Parallel.Foreach(mainList, (item) =>
	{
		if(item.key == "unRead")
		{
			foreach(var subItem in item.value) // evt do a List<string> temp = item.value first
			{
				foreach(var compItem in compareList)
				{
					if(compItem == subItem) 
                        lock(resList)
                            resList.Add(compItem);
				}
			}
		}
	});
    mainList.RemoveAll(item => item.key == "unRead");
