    var keepersByZone = teams.GroupBy(team => team.zone)
                             .Select(g => new { 
                                 name = g.Key, 
                                 players = g.SelectMany(team => team.players)
                                            .Where(player => plapyer.type == "Keeper")
                                            .OrderBy(player => player.name)
                                            .ToArray() 
                             });
