    public IEnumerable<Car> LoadCars(User user, int pageIndex, int pageSize)
    {
        var result = db.Cars
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToArray()
        ;
        var carsInInterest = result.Select(c => c.Id).ToArray();
        var allThePermissions = db.PermissionConfiguration
            .Where(pc => pc.User.Equals(user))
            .Where(pc => carsInInterest.Contains(pc.CarId))
            .ToArray()
        ;
        foreach (var carX in result)
        {
            var current = allThePermissions.FirstOrDefault(pc => pc.User.Equals(user) && pc.Car.Equals(carX));
            if (current != null)
            {
                if (!current.Permissions.HasFlag(CarFieldPermission.ViewConstructionYear))
                {
                    carX.ConstructionYear = null;
                }
            }
        }
        return result;
    }
