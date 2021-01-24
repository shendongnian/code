    DateTime startDate = DateTime.Parse("2018-02-01");
    DateTime endDate = DateTime.Parse("2018-02-03");
    bool manual = ...;
    
    loadingOrders.Where(
        o => o.DeliveryDate >= startDate &&
        o.DeliveryDate <= endDate &&
        manual ||
        o.DeliveryDate >= DateTime.Now &&
        !manual);
