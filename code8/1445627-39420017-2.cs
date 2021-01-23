    var interestingData = context.Cars
        .GroupBy(c => false)          // always get one result
        .Select(g => new
        {
            AnyVisibleCars = visibleCars.Any(),
            AnyInvisibleCars = invisibleCars.Any(),
            CarsWithXStatus = g.Select(c => c.Status == "x")
        })
        .Single();
    
    
