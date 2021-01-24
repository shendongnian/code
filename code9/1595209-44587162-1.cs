    private IQueriable<SOPOrderReturns> GetSOPOrderReturnsQuery(){
    var q = from hed in cxt.SOPOrderReturns.ToExpandable()
    join cus in cxt.SLCustomerAccounts on hed.CustomerID equals 
    cus.SLCustomerAccountID
    join ad in cxt.SOPDocDelAddresses on hed.SOPOrderReturnID equals 
    ad.SOPOrderReturnID
    
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
    
    return q.AsQueryable();
    }
