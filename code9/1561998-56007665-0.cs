      var invoices = db.QueryAsync<InvoiceModel, InvoiceItemModel, InvoiceModel>(
                        sql,
                        (invoiceModel, invoiceItemModel) =>
                        {
                            InvoiceModel invoiceEntry;
                            if (!invoiceDictionary.TryGetValue(invoiceModel.InvoiceId, out invoiceEntry))
                            {
                                invoiceEntry = invoiceModel;
                                invoiceEntry.InvoiceItems = new List<InvoiceItemModel>();
                                invoiceDictionary.Add(invoiceEntry.InvoiceId, invoiceEntry);
                            }
                            invoiceEntry.InvoiceItems.Add(invoiceItemModel);
                            return invoiceEntry;
                        },
                        null,
                        null,
                        true,
                        splitOn: "InvoiceItemId",
                        999)
                        .Result
                        .Distinct()
                        .ToList();
