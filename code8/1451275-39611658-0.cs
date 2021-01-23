    OrderProduct[] Customer1Order = OrderProductsOrder.GroupBy(o => o.OrderCustomerID).Where(o => o.Key == 1).ToArray();
    
    OrderProduct[] Customer2Order = OrderProductsOrder.GroupBy(o => o.OrderCustomerID).Where(o => o.Key == 2).ToArray();
    
    OrderProduct[] Customer3Order = OrderProductsOrder.GroupBy(o => o.OrderCustomerID).Where(o => o.Key == 3).ToArray();
