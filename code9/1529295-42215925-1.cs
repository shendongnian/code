    var n = 4;
    var query = (
            from car in _context.Cars
            select new CarsIndexViewModel()
            {
                Car = car,
                AllServices = car.CarServices,
                RecentServices = car.CarServices.OrderBy(x => ServiceDate).Take(n)
            }).ToList();
