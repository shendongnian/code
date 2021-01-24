    var suitableOrderLogistics = repository.OrderLogisticss.Where(ol => 
        ol.DepartureDate == 40826);
    var suitableOrderCarts = repository.OrderCarts.Where(oc => oc.Sealed != false);
    var model = repository.Orders
    .Join(
      suitableOrderLogistics,
      o => o.ID,
      ol => ol.OrderID,
      (o, ol) => new { OrderId = o.Id, Order = o, OrderLogistics = ol })
    .Join(
      suitableOrderCarts ,
      o => o.OrderId,
      oc => oc.OrderID,
      (o, oc) => new Order_OrderCart_OrderLogisticsModel { Order = o.Order, Logistics = o.OrderLogistics, Cart = oc });
