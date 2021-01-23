    if (orders != null)
    {
        var items = _unitOfWork.ItemRepository.GetAll();
        var itemOrders = items.GroupJoin(orders,
                                         item => item.ItemID,
                                         ord => ord.ItemID,
                                         (item, ordrs) => new
                                         {
                                             Orders = ordrs,
                                             itemName = item.ItemName
                                         });
                StatisticsResponse statsResponse = new StatisticsResponse()
                {
                     //...
                };
                foreach (var item in itemOrders)
                {
                    statsResponse.ItemOrders.Add(item.itemName, item.Orders.Count());
                }
                return statsResponse;
    }
