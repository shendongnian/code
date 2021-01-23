    var testgroup = lstFixtures.GroupBy(f => new { f.SportType, f.TournamentName },
                                            (key,g) => new
                                            {
                                                Sport = key.SportType,
                                                Tournament = key.TournamentName,
                                                Result = g.ToList()
                                            });
