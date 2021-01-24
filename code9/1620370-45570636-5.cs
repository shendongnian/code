    // 1st find out the ID of the one and only order the page is about
    int orderId = 4711; // can't help here - where do you intend to get it from?
    // 2nd retrieve from DB whatever we need later
    string customerName;
    using (var myEntities = new Entities())
    {
        var orderInfo = (
            from order in myEntities.Orders
            where order.OrderId == orderId
            select new { CustomerName = order.Customer.Name }
            ).SingleOrDefault();
        if (orderInfo == null) // error handling if orderId is bad
            throw new Exception("No such order found.");
        customerName = orderInfo.CustomerName;
    }
    // 3rd use what we know to update controls
    lblName.Text = customerName;
