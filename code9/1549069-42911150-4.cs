    IQueryable<Invoice> query= db.Invoices;
    BuildWhereClause(filter,ref query);
    var result= (from i in query
                 join cj in db.CustomerJobs on i.CustomerJobID equals cj.ID
                 join c in db.Customers on cj.CustomerId equals c.ID
                 select new InvoiceInfo()
                {
                    Number = i.InvoiceNumber,
                    Balance = i.InvoiceBalance,
                    PrePay = c.PrepaymentBalance
                });
