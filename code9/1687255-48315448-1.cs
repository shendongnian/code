    var BandL2 = from invoice in db.Invoices//Roll up to level 2
                             join ban in db.HierarchyTable
                             on invoice.AccNo equals ban.Ban
                             where invoice.GlobalInvoiceID == globalInvoice.Id and ban.HierAccNo = hierAccNo // dont skip this
    
                             group invoice by ban.HierAccNo into bandHierarchy
                             select new
                             {
                                 Level2Band = bandHierarchy.Key,
                                 Amount = bandHierarchy.Sum(m=> m.InvoiceAmount)
                             };
