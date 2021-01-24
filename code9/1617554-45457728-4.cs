    db.Orders.Select(order => new
    {
        Order = order,
        Tickets01 = db.Tickets_01.Where(ticket => ticket.OrderId == order.ID),
        Tickets02 = db.Tickets_02.Where(ticket => ticket.OrderId == order.ID)
    })
    .Select(orderWithTickets => new OrderData
    {
        orderName = orderWithTickets.Order.Name,
        tickets_01_ValueSumatorium = orderWithTickets.Tickets01.Sum(t => t.Value),
        numberOfTickets_01_withValueGreaterThan50 = orderWithTickets.Tickets01.Where(t => t.Value > 50).Sum(t => t.Value),
        // ...
    })
