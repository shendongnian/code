            var topRookie = driversFirstTable.Select(x => x.DriverRaces.Aggregate(new DriverAggregated() { Category = "Rookie", DriverName = x.DriverName }, (seed, race) =>
              {
                  if (race.Category == "Rookie")
                      seed.TotalPoints += race.Points;
                  return seed;
              }))
             .OrderByDescending(x => x.TotalPoints)
             .Take(3);
