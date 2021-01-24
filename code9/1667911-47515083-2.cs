    var cars = (from car in db.Cars
              select new CarDTO
              {                                       
                   Name = car.Name,
                   IdCar = car.IdCar,                                       
                   IdBase = car.id_Base,
               }).ToList(); //call .ToList() to fix possible EF errors by materializing all objects
    cars.ForEach(x => x.InnerCar = cars.FirstOrDefault(y => y.IdCar == x.IdBase));
