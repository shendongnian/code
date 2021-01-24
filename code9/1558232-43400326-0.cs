            var invoice2 = null;
            using (var db = new PortalEntities())
            {
                var invoices2 = from b in db.Invoices
                                where b.InvoiceID == invoiceIDParam
                                select b;
               //REMOVE THIS invoice2 = ToInvoiceDTO(invoices2.FirstOrDefault());
             }
           return invoice2;
    }
