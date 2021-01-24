    //New list to hold our new items
	var outputList = new List<MyClass>();		
		
    //Groups all the items together by DueDate
	foreach(var grouping in samples.GroupBy(d => d.DueDate))
	{		
        //Iterates through all items in a group (selecting the index as well)
		foreach(var item in grouping.Select((Value, Index) => new { Value, Index }))
		{
            //If this is any item after the first one, we remove the due date
			if(item.Index > 0)
			{
				item.Value.DueDate = null;
			}
			outputList.Add(item.Value);
		}
	}
