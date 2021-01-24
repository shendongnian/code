                var results = (from ct in companyTable.CustomerTables
                              join pt in companyTable.ProcessTables on ct.Id equals pt.CustomerId
                              select new { customerName = ct.CompanyTable.Name, processId = pt.Id, totalPayment = pt.TotalPayment, paidAmount = pt.PaymentReceived, remainingAmount = pt.TotalPayment - pt.PaymentReceived })
                              .GroupBy(x => x.processId)\
                               .Select((x,i) => new { index = i, customerName = x.FirstOrDefault().customerName, processId = x.FirstOrDefault().processId, 
                                   totalPayment = x.Sum(y => y.totalPayment),  paidAmount = x.Sum(y => y.paidAmount), remainingAmount = x.Sum(y => y.remainingAmount)})
                              .ToList();
