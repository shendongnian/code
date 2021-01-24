    var query = (from car in _context.Cars
                 select new CarsIndexViewModel()
                 {
                     Car = car,
                     Services = car.CarServices
                                   .OrderByDescending(cs => cs.ServiceDate)
                                   .Take(5) // only 5 most recent
                                   .ToList()
                 }).ToList();
