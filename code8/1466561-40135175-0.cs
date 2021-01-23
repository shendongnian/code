    var configurations = MasteryList.SelectMany(s => s)
                                    .GroupBy(gp => new {gp.ID, gp.Rank} )
                                    .OrderByDescending(g => g.Count())
                                    .Select(x => new {
                                                        Id = x.Key.ID,
                                                        rank = x.Key.Rank,
                                                        count = x.Count()
                                                     })
                                    .ToList();
