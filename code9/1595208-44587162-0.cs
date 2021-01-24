    var q = from hed in cxt.SOPOrderReturns.ToExpandable()
    var someVar = true | false;
    join cus in cxt.SLCustomerAccounts on hed.CustomerID equals 
    cus.SLCustomerAccountID
    join ad in cxt.SOPDocDelAddresses on hed.SOPOrderReturnID equals 
    ad.SOPOrderReturnID
    where hed.AnalysisCode1 == "SO" && hed.ReadyForInvoicePrint == someVar
    select new
    {
    hed.SOPOrderReturnID,
    hed.DocumentNo,
    hed.DocumentDate,
    cus.CustomerAccountNumber,
    Route = hed.AnalysisCode2,
    Drop = hed.AnalysisCode5,
    hed.ReadyForInvoicePrint,
    };
    q = q.RemoveExpandable();
    return q;
