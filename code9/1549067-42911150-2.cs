    IQueryable<Invoice> query= db.Invoices;
    BuildWhereClause(filter,ref query);
    var result= (from i in query
                 join cj in db.CustomerJobs on i.CustomerJobID equals cj.ID
                 join c in db.Customers on cj.CustomerId equals c.ID
                 let invoice = i
                 let customer = c
                 let customerJob = cj
                 select new InvoiceInfo()
                {
                    Number = invoice.InvoiceNumber,
                    Balance = invoice.InvoiceBalance,
                    PrePay = customer.PrepaymentBalance
                })
 
