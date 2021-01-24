    IEnumerable<Payment> payments = db.Payment
        .ApplyNotCancelledFilter()
        .ApplyTimeFilter(startTime, endTime);
  
    if (renderSectionOne) {
        payments = payments.ApplySectionOneFilter();
    }
    var paymentsByType = GroupByPaymentType(payments);
    var result = paymentsByType.Select(new
              {
                  name = grp.Key,
                  count = grp.Count(),
                  total = grp.Sum(x => x.pay.Amount)
              }
    );
