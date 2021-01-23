    public static class GameService
    {
        public static IQueryable<Models.Game> GetGames()
        {
            using (var gctx = new Contexts.GameContext())
            {
                return gctx.Games.Select(....);
            }
        }
    }
