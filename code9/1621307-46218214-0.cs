    foreach (var taxs in Invoice.InvoiceLineItems.Where(x => x.TaxId > 1).GroupBy(tax => tax.TaxId))
	{
		var tax = taxs.First();
		var tax1 = new LineItemTaxDto()
		{
			InvoiceLineItemId = tax.Id,
			InvoiceId = tax.InvoiceId,
			TaxId = tax.TaxId,
			TaxRate = tax.TaxRate,
			TaxAmount = tax.TaxAmount,
			TaxName = taxlabel + " (" + tax.TaxName + ")"
		};
		tax1.TaxAmount = taxs.Sum(x => x.TaxAmount);
		taxes.Add(tax1);
	}
	Invoice.ReceiptTaxList = taxes;
