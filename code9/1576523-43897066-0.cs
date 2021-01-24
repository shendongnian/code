    var List = result.GroupBy(x => new { x.Name, x.Id, x.Country })
                 .Select(g => new YourType { 
                     Id = g.Key.Id,
                     Name = g.Key.Name,
                     Country = g.Key.Country,
                     Match = g.Count()
                 })
                 .ToList();
