    IQueryable<OrderSummary> orders = inTestMode ?
        _contextComet.vwOrderSummaryTest.Select(item => 
            new OrderSummary { /*Populate properties*/ }) :
        _contextComet.vwOrderSummary; //Assuming item type of table is OrderSummary
    if (StartDate != null) 
    {
        orders = orders.Where(x => x.DateCreated >= StartDate);
    }
