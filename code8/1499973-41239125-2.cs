    var myOrderItem = new MyOrderItem()
    {
         StartedOn = item.StartedOn,
         Costs = new List<MyCost>();  // <=== This can also go in the default constructor
         ...
    };
    foreach (var cost in item.Costs)
    {
         myOrderItem.Costs.Add(new MyCost()
         {
             Value = cost.Value
             ...
         });
    }
    return myOrderItem;
