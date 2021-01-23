    List<oneViewModel> workOrderInfoList = (from abc in db.ABC
    join customer in db.Customers on abc.CustomerId equals customer.CustomerId into customers
    select new oneViewModel()
    {
        CustomerId = abc.CustomerId,
        OrderNumber = workOrderInfo.OrderNumber,
        OrderDate = abc.OrderDate
    }).ToList();
