    int orderId;
    string customerName;
    using (var myEntities = new Entities())
    {
        // retrieve from DB whatever we need (OrderId and Customer.Name of the order with the highest OrderId)
        var orderInfo = myEntities.Orders
            .Where(o => o.OrderId == myEntities.Orders.Max(o1 => o1.OrderId))
            .Select(o => new { o.OrderId, CustomerName = o.Customer.Name })
            .SingleOrDefault();
        if (orderInfo == null) throw new Exception("No order found.");
        orderId = orderInfo.OrderId;
        customerName = orderInfo.CustomerName;
    }
    // use what we know to update controls
    lblOrderId.Text = orderId.ToString();
    lblName.Text = customerName;
