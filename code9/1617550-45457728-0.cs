    from order in db.Orders
    select new
    {
        Order = order,
        Tickets01 = from ticket in db.Tickets_01 where ticket.OrderId == order.ID select ticket,
        Tickets02 = from ticket in db.Tickets_02 where ticket.OrderId == order.ID select ticket
    } into orderWithTickets
    select new OrderData
    {
        orderName = orderWithTickets.Order.Name,
        tickets_01_ValueSumatorium = orderWithTickets.Tickets01.Sum(t => t.Value),
        numberOfTickets_01_withValueGreaterThan50 = orderWithTickets.Tickets01.Where(t => t.Value > 50).Sum(t => t.Value),
        // ...
    };
