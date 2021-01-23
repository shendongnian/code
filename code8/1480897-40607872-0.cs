    List<oneViewModel> workOrderInfoList = (from abc in db.ABC
      join customer in db.Customers on abc.CustomerId equals customer.CustomerId into customers).ToList()
      Select(n => new oneViewModel()
      {
         CustomerId = n.CustomerId,
         OrderNumber = workOrderInfo.OrderNumber,
         OrderDate = n.OrderDate,
         SecondClassList = new List<SecondClass>(),
      }).ToList();
