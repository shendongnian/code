    var fieldNames = new List<string>()
	{
	    "Title",
	    "ID",
	    "DocumentOrder",
	    "FileRef"
	};
	var listItems = list.GetItems(query);
	foreach (var fieldName in fieldNames)
	{
		clientContext.Load(listItems,
		    items => items.Include(
		        item => item[fieldName]
		    )
		);
	}
	clientContext.ExecuteQuery();
