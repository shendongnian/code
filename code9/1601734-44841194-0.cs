    var joinedList = (from car in db.Car.Where(x => x.ProductionYear == 2005).AsQueryable()
                  join driver in db.Driver.AsQueryable() 
                    on car.Id equals driver.CarId
                  join building in db.Building.AsQueryable() 
                    on driver.BuildingId equals building.Id
                  select new Building
                  {
                     Name = building.Name,
                     Id = building.Id,
                     City = building.City,
                  }).ToList();
