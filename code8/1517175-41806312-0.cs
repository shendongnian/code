	PersonList = PersonList
           .GroupBy(s => new {s.LastName, s.Period})
           .Select(g => new Person { 
                LastName = g.Key.LastName,
                Period = g.Key.Period,
                Time = string.Join("  ", g.Select(v => CheckTime(v.Time, v.Period) + "' " + v.Gtype)) })
           .ToList();
