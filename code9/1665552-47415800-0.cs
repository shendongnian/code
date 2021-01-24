    var result = 
       from invoice in invoices
       join workDescription in invoiceWorkDescription 
           on invoice.Id equals workDescription.InvoiceId into workDescriptions
       join payment in invoicePayments
           on invoice.Id equals payment.InvoiceId into payments
       select new {
            InvoiceId = invoice.InvoiceId,
            Descriptions = string.Join(", ", workDescriptions.Select(wd => Description),
            TotalPayments = payment.Sum(p => p.Amount) }
