    IEnumberable<CarEntity> carEntities = repository.GetCars();
    IEnumerable<Car> cars = 
        carEntities
        .Select(c => 
             new Car
             {
                 CarId = c.Id,
                 CarColor = c.Color,
                 //etc.
             });
