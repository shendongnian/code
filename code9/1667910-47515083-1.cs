    var cars = (from car in db.Cars
              select new CarDTO
              {                                       
                   Name = inCar.Name,
                   IdCar = inCar.IdCar,                                       
                   IdBase = inCar.id_Base,
               }).ToList(); //call .ToList() to fix possible EF errors by materializing all objects
    cars.ForEach(x => x.InnerCar = cars.FirstOrDefault(y => y.IdCar == x.IdBase));
