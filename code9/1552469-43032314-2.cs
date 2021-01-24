            var teamResults = from game in games
                        where game.Team1.Name == relevantTeam || game.Team2.Name == relevantTeam
                        let teamWon = (game.Team1.Name == relevantTeam && game.Result == GameResult.Team1Won) ||
                                      (game.Team2.Name == relevantTeam && game.Result == GameResult.Team2Won)
                        let draw = game.Result == GameResult.Draw
                        select teamWon ? 
                               TeamResultInAGame.TeamWon :
                               draw ? TeamResultInAGame.Draw : TeamResultInAGame.TeamLost;
