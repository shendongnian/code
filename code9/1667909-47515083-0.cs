    var cars = from car in db.Cars
              select new CarDTO
              {                                       
                   Name = inCar.Name,
                   IdCar = inCar.IdCar,                                       
                   IdBase = inCar.id_Base,
               };
    cars.ForEach(x => x.InnerCar = cars.FirstOrDefault(y => y.IdCar == x.IdBase));
