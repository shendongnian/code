        using (iraqEntities dc = new iraqEntities())
        {
            InvoiceTypes = dc.stkInvoicesTypesTbls
                             .Include(x=>x.stkInvoicesTbls)
                             .OrderBy(a => a.invTypeDesc)
                             .ToList();
        }
