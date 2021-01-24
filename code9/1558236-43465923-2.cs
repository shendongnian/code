    var invoicesQuery = from a in db.Invoices
                 where a.InvoiceID == invoiceIDParam
                select a;
    
    List<InvoiceDTO>  listTest = invoicesQuery.ToList().Select(x => ToInvoiceDTO(x)).ToList();
