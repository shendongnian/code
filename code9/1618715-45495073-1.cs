	var buyerMap = AllBuyers
		.Where(b => b.Name.IndexOf(SearchValue, StringComparison.OrdinalIgnoreCase) >= 0)
		.ToDictionary(b => b.BuyerIdentifier);
	
	var invoiceLookup = AllInvoices
		.Where(i => buyerMap.ContainsKey(i.BuyerID))
		.ToLookup(x => x.BuyerID);
	
	foreach (var invoiceGroup in invoiceLookup)
	{
		var buyerId = invoiceGroup.Key;
		var buyer = buyerMap[buyerId];
		var invoicesForBuyer = invoiceGroup.ToList();
		
		// Do your stuff with buyer and invoicesForBuyer
	}
