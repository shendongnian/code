    [Authorize]
    public MyOrderItem Get(int id)
    {
        using (var entities = new customappsEntities())
        {
            var item = entities.OrderItems.FirstOrDefault(e => e.pkOrderItemID == id);
            return new MyOrderItem()
            {
                 StartedOn = item.StartedOn,
                 ...
            };
        }
    }
