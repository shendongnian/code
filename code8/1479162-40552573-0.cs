    dbContext.Client
        .GroupBy(c => c.villeId)
        .Select(g => new {
            CityName = dbContext.Villes.Where(v => v.Id_ville == g.Key),
            NumberOfClient = g.Count()
        }).ToList();
