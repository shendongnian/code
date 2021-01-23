    community.Tournaments.SelectMany(x => x.Rounds.
                                SelectMany(y => y.Matches.Select(m => new { Turnament = x, Match = m }))).Where(j => j.Match.Away.Members.Count > 0).
                                Select(t => new TeamLeagueMatch()
                                {
                                    Name = t.Turnament.Name
                                }).ToList();
