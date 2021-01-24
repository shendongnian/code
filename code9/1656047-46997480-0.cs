    var uniqueCustomerIdList = services
        .GroupBy(x => x.CustomerId)
        .Select(cl =>
        {
            var pdfServices = services.Where(x => x.CustomerId == cl.First().CustomerId).ToList();
            return new Customer
            {
                CustomerId = cl.First().CustomerId,
                CustomerName = cl.First().CompanyName,
                PdfServices = pdfServices,
                PdfServiceLines = pdfServices
                    .GroupBy(l => l.ServiceDescription)
                    .Select(cy => new PdfServiceLine
                    { 
                        ServiceName = cy.First().ServiceDescription,
                        Quantity = cy.Count(),
                        UnitPrice = cy.First().PlanCharge,
                        ServiceCharges = services.Where(x => x.CustomerId == cl.First().CustomerId && x.ServiceDescription == cy.First().ServiceDescription).Sum(y => y.TotalBill),
                        UsageCharges = usage.Where(x => x.CustomerId == cl.First().CustomerId && x.ServiceDescription == cy.First().ServiceDescription).Sum(y => y.Charge),
                        Total = cy.Sum(c => c.PlanCharge),
                    }).ToList(),
                PdfUsages = usage.Where(x => x.CustomerId == cl.First().CustomerId).ToList()
            };
        })
        .ToList();
