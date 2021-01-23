    // Use .ToList() at the end so you do not load all records into memory
    var filtered = db.Payments.Where(x => x.PayDate >= startdate && x.PayDate <= enddate && x.POK && x.MemberId==MemberId).ToList();
    var model = filtered.GroupBy(x => new { member = x.MemberId, txn = x.TransactId, pd = x.PayDate })
        .Select(x => new MemberPaymentVM()
        {
            MemberName = x.First().Member.MemberName,
            TransactId = x.Key.txn,
            PayDate = x.Key.pd,
            TotalAmount = x.Sum(y => y.Amount),
            Payments = x.Select(y => new CategoryAmountsVM()
            {
                CategoryId = y.Category.CategoryName,
                Amount = y.Amount
            })
        });
    return View(model);
