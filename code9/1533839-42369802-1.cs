        using (iraqEntities dc = new iraqEntities())
        {
            InvoiceTypes = dc.stkInvoicesTypesTbls
                             .Include("stkInvoicesTbls")
                             .OrderBy(a => a.invTypeDesc)
                             .ToList();
        }
