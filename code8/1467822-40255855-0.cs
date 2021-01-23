        public static List<Models.Game> GetGames()
        {
            using (var gctx = new Contexts.DatabaseContext())
            {
                
                return gctx.Games.Include(g => g.Teams).Include(g => g.Teams.TeamsList.Select(t => t.Players)).ToList();
            }
        }
