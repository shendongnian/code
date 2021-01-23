	double inputAmount = Convert.ToDouble(txtAmount.Text);
	var result = db.tblCustomerOrders
		.GroupBy(m => m.CustomerID)
		.Select(g => new
		{
			CustomerID = g.Key,
			Sum = g.Sum(m => m.Amount)
		})
		.Where(m => m.Sum > inputAmount)
		.Select(m => m.CustomerID)
		.ToList();
