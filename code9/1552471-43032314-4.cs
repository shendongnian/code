        private class Team
        {
            public string Name { get; set; }
        }
        private class Game
        {
            public Team Team1 { get; set; }
            public Team Team2 { get; set; }
            public GameResult Result { get; set; }
        }
        enum GameResult
        {
            Team1Won,
            Draw,
            Team2Won
        }
