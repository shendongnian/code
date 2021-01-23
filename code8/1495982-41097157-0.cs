    var newCarList = NormalList
       .GroupBy(c => new {  c.Make, c.Model })
       .Select(carGroup => new Car{ 
           Make = carGroup.Key.Make, 
           Model = carGroup.Key.Model,
           ServiceCost = carGroup.Sum(c => c.ServiceCost)
        })
       .ToList();
