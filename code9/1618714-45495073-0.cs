	var invoiceLookup = AllInvoices.ToLookup(x => x.BuyerID);
	foreach (var buyer in AllBuyers)
	{
		// Lookup returns Enumerable.Empty<Invoice>() when buyer key not found
		var invoicesForBuyer = invoiceLookup[buyer.BuyerIdentifier].ToList();
		if (invoicesForBuyer.Count == 0)
		{
			// No invoices for buyer
			continue;
		}
		
		// Do your stuff with invoicesForBuyer
	}
