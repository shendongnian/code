    public AddUpdateOrder(Order o)
    {
        using(var ctx = new YourDataModelContext())
        {
            if(ctx.Orders.Any(x => x.OrderId == o.OrderId && x.CustomerId == o.CustomerId && x.PartId == o.PartId && x.OrderDate == o.OrderDate))
            {
                var e = ctx.Orders.Where(x => x.OrderId == o.OrderId && x.CustomerId == o.CustomerId && x.PartId == o.PartId && x.OrderDate == o.OrderDate).FirstOrDefault();
                e.Quantity += 1;
                ctx.Entry(e).State = Modified; 
            }
            else
            {
                Order e = new Order() { OrderId = o.OrderId, CustomerId = o.CustomerId, PartId = o.PartId, OrderDate == o.OrderDate, Quantity = 1};
                ctx.Orders.Add(e);
            }
            ctx.SaveChanges();
        }
    }
