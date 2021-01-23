     var orders = new List<Order>();
     await items.ForEachAsync(i =>
     {
        var order = new Order
        {
           ResultNo = i.OrderNo,
           CustomerName = i.Customer.Name,
           PaymentType = i.Payment.Type
        };
        orders.Add(order);
     }).ContinueWith(t =>
     {
        response = new Response<IEnumerable<Order>>(orders);
     });
