    var mergedHistory = new APIBillingHistory {
        BillingHistoryDetails = history
            .BillingHistoryDetails
            .GroupBy(detail => detail.BillId)
            .Select(detailGroup => new APIBillingHistoryDetails {
                BillId = detailGroup.Key,
                PaymentType = detailGroup.SelectMany(p => p.PaymentType)
                    .GroupBy(pymtType => pymtType.Description)
                    .Select(pymtTypeGroup => new APIBillingHistoryPaymentType {
                        Description = pymtTypeGroup.Key,
                        Principal = pymtTypeGroup.Sum(t => t.Principal)
                    }).ToList()
            }).ToList()
    };
