        public static class GameExtensions
        {
            public static List<string> GetSummonerList(this Game game)
            {
                return game.SummonerStatsList.Select(x => x.PropertyName).ToList();
            };
        }
