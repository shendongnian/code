    var result = dbContext.Villes
    			.Join(dbContextClients, v => v.IdVille, c => c.IdVille, (v, c)  => new { client = c, ville = v })
    			.GroupBy(j => j.ville.IdVille)
    			.Select(g => new {
    				VilleName = g.First().ville.Name,
    				NumberOfClients = g.Count()
    			}).ToList();
