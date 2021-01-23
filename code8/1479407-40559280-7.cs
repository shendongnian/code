    foreach (var kv in dishGroupingDictionary)
    {
	    Console.WriteLine("Pdv:{0},Pla_Id:    
        {1},Price{2}",kv.Key.Pdv,kv.Key.Pla_ID,kv.Key.Price);
	
	    int totalQuantity = kv.Value.Sum(x => x.Value);
	
	    Console.WriteLine("Total Quantity: {0}", totalQuantity);
	
	    double totalPrice = totalQuantity * kv.Key.Price;
	
	    Console.WriteLine("Total Price: {0}", totalPrice);
	
	  // Day wise data printing:		
	  foreach(var kvChild in kv.Value)
	    Console.WriteLine("Day:{0},Quantity:{1}",kvChild.Key,kvChild.Value);		
	
    }
