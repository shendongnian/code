    if (customerUnits.Any())
    {
        foreach (var customerUnit in customerUnits)
        {
            customerUnit.CustomerUnitCars.ToList().ForEach(c => c.Assigned = true);
            foreach (var customerUnitCar in customerUnit.CustomerUnitCars)
            {
                carIds.Add(customerUnitCar.CarId);
                customerData.AvailableCars
                    .Where(availableCar => availableCar.CarId == customerUnitCar.CarId)
                    .ToList()
                    .ForEach(availableCar => availableCar.Assigned = true);
            }
        }
    }
