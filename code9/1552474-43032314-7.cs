            Team manchester = new Team() { Name = "Manchester" };
            Team chelsea = new Team() { Name = "Chelsea" };
            Team arsenal = new Team() { Name = "Arsenal" };
            List<Game> games = new List<Game>();
            games.Add(new Game() { Team1 = manchester, Team2 = chelsea, Result = GameResult.Draw });
            games.Add(new Game() { Team1 = arsenal, Team2 = manchester, Result = GameResult.Team1Won });
            games.Add(new Game() { Team1 = chelsea, Team2 = arsenal, Result = GameResult.Draw });
            games.Add(new Game() { Team1 = chelsea, Team2 = manchester, Result = GameResult.Draw });
            string relevantTeam = manchester;
            var teamResults = from game in games
                        where game.Team1.Name == relevantTeam.Name || game.Team2.Name == relevantTeam.Name
                        let teamWon = (game.Team1.Name == relevantTeam.Name && game.Result == GameResult.Team1Won) ||
                                      (game.Team2.Name == relevantTeam.Name && game.Result == GameResult.Team2Won)
                        let draw = game.Result == GameResult.Draw
                        select teamWon ? 
                               TeamResultInAGame.TeamWon :
                               draw ? TeamResultInAGame.Draw : TeamResultInAGame.TeamLost;
            Console.WriteLine("Wins Count: " + teamResults.Count(result => result == TeamResultInAGame.TeamWon));
            Console.WriteLine("Lost count: " + teamResults.Count(result => result == TeamResultInAGame.TeamLost));
            Console.WriteLine("Draw count: " + teamResults.Count(result => result == TeamResultInAGame.Draw));
            Console.WriteLine("Total score: " + teamResults.Sum(result => (int)result));
 
