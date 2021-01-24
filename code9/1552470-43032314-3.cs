            Team manchester = new Team() { Name = "Manchester" };
            Team Chelsea = new Team() { Name = "Chelsea" };
            Team Arsenal = new Team() { Name = "Arsenal" };
            List<Game> games = new List<Game>();
            games.Add(new Game() { Team1 = manchester, Team2 = Chelsea, Result = GameResult.Draw });
            games.Add(new Game() { Team1 = Arsenal, Team2 = manchester, Result = GameResult.Team1Won });
            games.Add(new Game() { Team1 = Chelsea, Team2 = Arsenal, Result = GameResult.Draw });
            games.Add(new Game() { Team1 = Chelsea, Team2 = manchester, Result = GameResult.Draw });
            string relevantTeam = "Manchester";
            var teamResults = from game in games
                        where game.Team1.Name == relevantTeam || game.Team2.Name == relevantTeam
                        let teamWon = (game.Team1.Name == relevantTeam && game.Result == GameResult.Team1Won) ||
                                      (game.Team2.Name == relevantTeam && game.Result == GameResult.Team2Won)
                        let draw = game.Result == GameResult.Draw
                        select teamWon ? 
                               TeamResultInAGame.TeamWon :
                               draw ? TeamResultInAGame.Draw : TeamResultInAGame.TeamLost;
            Console.WriteLine("Wins Count: " + teamResults.Count(result => result == TeamResultInAGame.TeamWon));
            Console.WriteLine("Lost count: " + teamResults.Count(result => result == TeamResultInAGame.TeamLost));
            Console.WriteLine("Draw count: " + teamResults.Count(result => result == TeamResultInAGame.Draw));
            Console.WriteLine("Total score: " + teamResults.Sum(result => (int)result));
 
