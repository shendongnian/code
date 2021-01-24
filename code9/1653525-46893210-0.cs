    // Initialize by using default Lazy<T> constructor. The 
    // Orders array itself is not created yet.
    Lazy<Orders> _orders = new Lazy<Orders>();
    // Initialize by invoking a specific constructor on Order which
    // will be used when Value property is accessed
    Lazy<Orders> _orders = new Lazy<Orders>(() => new Orders(100));
    // Lazy<Orders> will create the array only if displayOrders is 
    // which will go through path where _orders.Value is accessed
    if (displayOrders == true)
    {
        DisplayOrders(_orders.Value.OrderData);
    }
    else
    {
        // Don't waste resources getting order data.
    } 
