    var TaxList = Invoice.InvoiceLineItems.Where(x => x.TaxId > 1).GroupBy(y=>y.TaxId > 1).Select(x =>
     {
     	return new KeyValuePair<LineItemTaxDto, ObservableCollection<LineItemTaxDto>>(new LineItemTaxDto()
        {
    		InvoiceLineItemId = x.First().Id,
            InvoiceId = x.First().InvoiceId,
            TaxId = x.First().TaxId,
            TaxRate = x.First().TaxRate,
    		TaxAmount = x.Sum(a=>a.TaxAmount),
            TaxName = taxlabel + " (" + x.First().TaxName + ")"
    	}, x.First().LineItemTaxes);
     });
    var taxes = new ObservableCollection<LineItemTaxDto>();
    foreach (var tax in TaxList.GroupBy(tax => tax.Key.TaxId).Select(grp => grp.First()))
    {
        taxes.Add(tax.Key);
        foreach (var subtax in tax.Value.Where(x => x.TaxId > 0))
        {
            taxes.Add(subtax);
        }
    }
    Invoice.ReceiptTaxList = taxes;
