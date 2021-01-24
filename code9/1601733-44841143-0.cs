    var joinedList = (from car in db.Car.GetQueryable().Where(x => x.ProductionYear == 2005)
                  join driver in db.Driver.GetQueryable() on car.Id equals driver.CarId
                  join building in db.Building.GetQueryable() on driver.BuildingId equals building.Id
                  select new Building
                  {
                     Name = building.Name;
                     Id = building.Id;
                     City = building.City;
                  }).ToList();
