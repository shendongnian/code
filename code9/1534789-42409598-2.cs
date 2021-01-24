    public int DoTheWork(Order order)
    {
        // assign properties just as an example
        order.ShippingMethod = "Fedex";
        order.OrderTotal = 90;
        order.OrderWeight = 12;
        order.OrderZipCode = 98109;
        return shippingStrategy.CalculateShippingCost(order);
    }
    
