            var topRookies = driversFirstTable.Select(x => x.DriverRaces.Aggregate(new DriverAggregated() { Category = "Rookie", DriverName = x.DriverName}, (race1, race2) =>
             {
                 if (race2.Category == "Rookie")
                     race1.TotalPoints += race2.Points;
                 return race1;
             }))
             .OrderByDescending(x => x.TotalPoints)
             .Take(3);
