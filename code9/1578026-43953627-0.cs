    IEnumerable<Car> summedUp = cars.GroupBy(c => new { c.Make, c.Model })
        .Select(g => new Car()
            {
                Make = g.Key.Make,
                Model = g.Key.Model,
                AccidentCount = g.Sum(c => c.AccidentCount),
                MaintenanceCount = g.Sum(c => c.MaintenanceCount)
            });
