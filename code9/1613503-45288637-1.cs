    var listA = new List<A>();
    while(dr.Read())
    {
    	var itemA = //...code...
    	
    	// ctx.Add(itemA); // DON'T do it...
    	list.Add(itemA);
    }
    
    ctx.AddRange(listA);
