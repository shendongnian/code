    var players = new List<PlayersInGame>
                {
                    new PlayersInGame
                    {
                        PlayerId = 1,
                        GameId = 1,
                        PlayerName = "Manu Ginobili",
                        TeamId = 1,
                        TeamName = "Spurs"
                    },
                    new PlayersInGame
                    {
                        PlayerId = 3,
                        GameId = 1,
                        PlayerName = "Michael Jordan",
                        TeamId = 1,
                        TeamName = "Spurs"
                    },
                    new PlayersInGame
                    {
                        PlayerId = 3,
                        GameId = 2,
                        PlayerName = "Michael Jordan",
                        TeamId = 3,
                        TeamName = "Bulls"
                    },
                    new PlayersInGame
                    {
                        PlayerId = 2,
                        GameId = 1,
                        PlayerName = "James Harden",
                        TeamId = 2,
                        TeamName = "Rockets"
                    }
                };
    
                var games = new List<Games>
                {
                    new Games
                    {
                        GameId = 1,
                        AwayTeamId = 2,
                        AwayTeamName = "Rockets",
                        AwayTeamScore = 107,
                        HomeTeamId = 1,
                        HomeTeamName = "Spurs",
                        HomeTeamScore = 110
                    },
                    new Games
                    {
                        GameId = 2,
                        AwayTeamId = 2,
                        AwayTeamName = "Rockets",
                        AwayTeamScore = 107,
                        HomeTeamId = 3,
                        HomeTeamName = "Bulls",
                        HomeTeamScore = 110
                    }
                };
    
                /*
               string PlayerName,
               string Teams,
               int GameCount,
               int NumberOfWins*/
    
                var result = (from g in games
                              join p in players on g.GameId equals p.GameId
                              select new
                              {
                                  PlayerNAme = p.PlayerName,
                                  Teams = string.Join(",", players.Where(x => x.PlayerName == p.PlayerName).Select( m=> new { m.TeamName })),
                                  GameCount = players.Count(x => x.PlayerName == p.PlayerName),
                                  NumberOfWins = games.Count(m => ((players.Where(x => x.PlayerName == p.PlayerName).Select(x => x.TeamId)).Contains(m.AwayTeamId) && m.AwayTeamScore > m.HomeTeamScore) || ((players.Where(x => x.PlayerName == p.PlayerName).Select(x => x.TeamId)).Contains(m.HomeTeamId) && m.HomeTeamScore > m.AwayTeamScore))
                              }
                              ).Distinct();
