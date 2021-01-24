        class Player
        {
            public Point Position { get; set; }
        }
        public void Test()
        {
            var players = new Dictionary<int, Player>();
            var msg = players.Aggregate(
                  string.Empty, 
                 (current, p) => current + 
                           $"{p.Key}%{p.Value.Position.X}%{p.Value.Position.Y}|");
        }
