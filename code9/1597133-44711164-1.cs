    var result = new APIBillingHistory {
        BillingHistoryDetails = history.BillingHistoryDetails
        .GroupBy(g => g.BillId)
        .Select(g => new APIBillingHistoryDetails {
            BillId = g.Key,
            PaymentType = g.SelectMany(p => p.PaymentType)
            .GroupBy(p => p.Description)
            .Select(p => new APIBillingHistoryPaymentType {
                Description = p.Key,
                Principal = p.Sum(t => t.Principal)
            }).ToList()
        }).ToList()
    };
