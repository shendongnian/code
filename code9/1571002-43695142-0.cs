    var invoicesSelPartDescription = invoices
        .Select(invoice => new
			{
				invoice.PartDescription,
				invoice.Quantity
			})
		.OrderBy(x => x.Quantity);
