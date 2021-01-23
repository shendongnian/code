    public class Level
    {
        private readonly Team[,] _game;
        public Level(int extent)
        {
            _game = new Team[extent, extent];
        }
        public bool HasWon(Team team)
        {
            var yMax = GetYMax();
            var xMax = GetXMax();
            var won = false;
            // check horizontally
            for (var y = 0; y < yMax; y++)
            {
                won = false;
                for (var x = 0; x < xMax; x++)
                    won |= _game[y, x] == team;
                if (won) return true;
            }
            // TODO check vertically
            // TODO check diagonally
            return won;
        }
        public void SetTile(Team team, int x, int y)
        {
            var xMax = GetXMax();
            var yMax = GetYMax();
            if ((x < 0) || (x > xMax))
                throw new ArgumentOutOfRangeException("x");
            if ((y < 0) || (y > yMax))
                throw new ArgumentOutOfRangeException("y");
            _game[y, x] = team;
        }
        private int GetXMax()
        {
            var xMax = _game.GetUpperBound(1);
            return xMax;
        }
        private int GetYMax()
        {
            var yMax = _game.GetUpperBound(0);
            return yMax;
        }
    }
    public enum Team
    {
        Red,
        Blue
    }
