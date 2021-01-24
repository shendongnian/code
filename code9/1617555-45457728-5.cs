    db.Orders.Select(order => new OrderData
    {
        orderName=order.Name,
        tickets_01_ValueSumatorium = order.Tickets_01.Sum(t=>t.Value),
        numberOfTickets_01_withValueGreaterThan50 = order.Tickets_01.Where(t => t.Value > 50).Sum(t => t.Value)
        // ...
    });
