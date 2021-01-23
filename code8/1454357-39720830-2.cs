        var source = new List<Order> {
	    new Order {ZipCode = "01", TimeSlot ="A" },        
	    new Order {ZipCode = "01", TimeSlot ="A" },
	    new Order {ZipCode = "02", TimeSlot ="B" },
            new Order {ZipCode = "01", TimeSlot ="B" },
            new Order {ZipCode = "01", TimeSlot ="C" }
    	};
		var result = source
			.GroupBy(s => s.ZipCode)
			.Select(g => new PivotData
					{
						ZipCode = g.Key,
						OrdersCount = g.Count(),
						TimeSlots = g.GroupBy(x => x.TimeSlot).ToDictionary(x => x.Key, x => x.Count())
					}).ToList();
			
		foreach(var item in result) {
			System.Console.WriteLine("ZipCode: " + item.ZipCode + " - " + "Orders count: " + item.OrdersCount);
			Console.WriteLine("Time slots:");
			foreach(var timeSlot in item.TimeSlots) {
				System.Console.WriteLine(timeSlot.Key + " - " + timeSlot.Value);
			}
			Console.WriteLine("---");
		}
