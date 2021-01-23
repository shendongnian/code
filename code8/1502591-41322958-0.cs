    List<GroupedItem> result = new List<GroupedItem>();
    var groupedResult = _groupedItems.GroupBy(x=>x.Seller);
		
	foreach(var grouping in groupedResult)
	{
			
		var row = grouping.First();
			
		row.TransactionPrice = grouping.Sum(x=>x.TransactionPrice);
		row.Sales = grouping.Sum(x=>x.Sales);
        
        result.Add(row);
	}
