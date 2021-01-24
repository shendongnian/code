    IEnumerable<Payment> payments = db.Payment
        .ApplyNotCancelledFilter()
        .ApplyTimeFilter(startTime, endTime);
  
    if (renderSectionOne) {
        payments = payments.ApplySectionOneFilter();
    }
    var paymentsByType = payments.GroupByType();
    var result = paymentsByType.Select(new
              {
                  name = grp.Key,
                  count = grp.Count(),
                  total = grp.Sum(x => x.pay.Amount)
              }
    );
