            players
                .Where((p, i) =>
                    {
                        Player pp = playerPosition[i];
                        bool result = p.FirstName == pp.FirstName && p.LastName == pp.LastName && p.TeamName == pp.TeamName;
                        if (result)
                        {
                            p.Position = pp.Position;
                        }
                        return result;
                    }).ToList();  // note that this will create a copy of players List
