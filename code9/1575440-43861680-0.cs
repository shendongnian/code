    // grouping
    var groups = products.GroupBy(x => new 
    { 
        Order = x.Order, 
        GrandTotal = x.GrandTotal, 
        Date = x.Date, 
        Ship_FirstName = x.Ship_FirstName, 
        Ship_LastName = x.Ship_LastName 
    });
    // flattening the group
    yourRepeater.DataSource = groups.Select(item => new 
      {
        Order = item.Key.Order,
        GrandTotal = item.Key.GrandTotal,
        Date = item.Key.Date,
        Ship_FirstName = item.Key.Ship_FirstName,
        Ship_LastName = item.Key.Ship_LastName
      }).ToList();
    
    // binding
    yourRepeater.DataBind();   
