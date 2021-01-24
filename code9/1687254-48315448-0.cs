    var hierAccNo = 123;
    var details =  from invoice in db.Invoices
                             join ban in db.HierarchyTable
                             on invoice.AccNo equals ban.Ban
                             where invoice.GlobalInvoiceID == globalInvoice.Id
    and ban.HierAccNo = HierAccNo;
