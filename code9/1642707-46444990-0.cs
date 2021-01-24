	var result = new List<List<SupplierDetails>>();
	result.Add(new List<SupplierDetails> { collection[0] });
	foreach (var item in collection.Skip(1))
	{
		if (result.Last()[0].Status == item.Status)
			result.Last().Add(item);
		else
			result.Add(new List<SupplierDetails> { item });
	}
	
