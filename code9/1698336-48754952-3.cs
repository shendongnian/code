    Func<LoadingOrder, bool> deliveryDateCondition;
    if(manual)
        deliveryDateCondition = loadingOrder => 
            loadingOrder.deliveryDate >= startDate && loadingOrder.deliveryDate <= endDate;
    else
    {
        var now = DateTime.Now;
        deliveryDateCondition = loadingOrder => loadingOrder.deliveryDate >= now;
    }
        
