    public int IntroduceOrder(...)
    {
        using (MyDbContext dbContext = ...)
        {
            Order orderToAdd = new Order()
            {
                ...
            }
            var addedOrder = dbContext.Orders.Add(orderToAdd);
            dbContext.SaveChanges();
            return addedOrder.Id;
        }
    }
    public OrderLine AddOrderLine(int orderId, ...)
    {
        using (MyDbContext dbContext = ...)
        {
            // get the sequenceNo from the orderline of the order with orderId
            // with the highest sequenceNo
            // = first element when ordered descending
            int highestSeqenceNo = dbContext.OrderLines
                .Where(orderLine => orderLine.OrderId == orderId)
                .Select(orderLine => orderLine.SequenceNo)
                .OrderByDescending(sequenceNo => sequenceNo)
                .FirstOrDefault();
           // if there were no order lines yet, highestSequenceNo has value 0
           const int sequenceNoFirstOrderLine = 1;
           // or whatever value you want as sequenceNo for the first OrderLine
           int nextSequenceNo = (highestSequenceNo == 0) ? 
               sequenceNoFirstOrderLine :
               highestSequenceNo + 1;
           OrderLine orderLineToAdd = new OrderLine()
           {
               ...
               SequenceNo = nextSequenceNo,
           };
           var addedOrderLine = dbContext.Orders.Add(orderLineToAdd);
           dbContext.SaveChanges();
           return addedOrderLine;
        }
    }
