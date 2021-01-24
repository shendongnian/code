    List<APIBillingHistoryDetails> newList = (from item in BillingHistoryDetails.GroupBy(t => t.BillId)
    	let paymentType = item
    		.SelectMany(t => t.PaymentType)
    		.GroupBy(t => t.Description)
    		.Select(t => new APIBillingHistoryPaymentType
    		{
    			Description = t.Key.Description,
    			Principal = t.Sum(s => s.Principal)
    		})
    		.ToList()
    	select new APIBillingHistoryDetails
        { 
            BillId = item.Key,
            PaymelntType = paymentType
        }
    ).ToList();
