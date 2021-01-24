    var merged = new APIBillingHistory {
        BillingHistoryDetails = history
            .BillingHistoryDetails
            .GroupBy(detail => detail.BillId) //Group same bill Ids
            .Select(detailGroup => new APIBillingHistoryDetails {
                BillId = detailGroup.Key,
                PaymentType = detailGroup.SelectMany(p => p.PaymentType) //Get all payments
                    .GroupBy(pymtType => pymtType.Description) //and group them by description
                    .Select(pymtTypeGroup => new APIBillingHistoryPaymentType { //construct payment type
                        Description = pymtTypeGroup.Key,
                        Principal = pymtTypeGroup.Sum(t => t.Principal) // summing all grouped principals
                    }).ToList()
            }).ToList()
    };
