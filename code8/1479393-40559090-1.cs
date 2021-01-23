    var data = db.Dishes.Where(...); // your query
    int daysInMonth = 31; // hard coded for November 2016
    // Group the data and initialize the collection of days for each group
    var model = data.GroupBy(x => new { Pdv = x.Pdv, Pla_ID = x.Pla_ID, Price = x.Price })
        .Select(x => new DishVM()
        {
            Pdv = x.Key.Pdv,
            Pla_ID = x.Key.Pla_ID,
            Price = x.Key.Price,
            Days = new List<int>(new int[daysInMonth]),
            Data = x
        }).ToList();
    // Assign the quantity for each day
    foreach (var record in model)
    {
        foreach(var dish in record.Data)
        {  
            int index = dish.Fecha.Day - 1;
            record.Days[index] = dish.Quantity;
            record.TotalQuantity += dish.Quantity;
        }
        record.TotalPrice = record.TotalQuantity * record.Price;
    }
            
