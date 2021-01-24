    public class Game
    {
        public Game() : this(new Coin[GridWidth, GridHeight])
        {
        }
        public Game(Coin[,] grid)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid));
            if (grid.GetUpperBound(0) != GridWidth - 1)
                throw new ArgumentOutOfRangeException(nameof(grid));
            if (grid.GetUpperBound(1) != GridHeight - 1)
                throw new ArgumentOutOfRangeException(nameof(grid));
            Grid = grid;
        }
        private static int GridWidth { get; } = 3;
        private static int GridHeight { get; } = 3;
        private static int GridExtent => 3;
        private Coin[,] Grid { get; }
        public Coin GetCoin(int col, int row)
        {
            Check(col, row);
            var coin = Grid[col, row];
            return coin;
        }
        public void SetCoin(Coin coin, int col, int row)
        {
            Check(col, row);
            Grid[col, row] = coin;
        }
        public bool Check()
        {
            for (var col = 0; col < GridWidth; col++)
                if (CheckCol(col))
                    return true;
            for (var row = 0; row < GridHeight; row++)
                if (CheckRow(row))
                    return true;
            return false;
        }
        private bool CheckCol(int col)
        {
            CheckColIndex(col);
            var coins = new Coin[GridHeight];
            for (var row = 0; row < GridHeight; row++)
                coins[row] = GetCoin(col, row);
            var check = Check(coins);
            return check;
        }
        private bool CheckRow(int row)
        {
            CheckRowIndex(row);
            var coins = new Coin[GridWidth];
            for (var column = 0; column < GridWidth; column++)
                coins[column] = GetCoin(column, row);
            var check = Check(coins);
            return check;
        }
        private bool Check(Coin[] coins)
        {
            if (coins == null)
                throw new ArgumentNullException(nameof(coins));
            var any = Coins.All.Any(s => s.Where(coins.Contains).Distinct().Count() == GridExtent);
            return any;
        }
        private static void Check(int col, int row)
        {
            CheckColIndex(col);
            CheckRowIndex(row);
        }
        private static void CheckColIndex(int col)
        {
            if (col < 0 || col >= GridWidth)
                throw new ArgumentOutOfRangeException(nameof(col));
        }
        private static void CheckRowIndex(int row)
        {
            if (row < 0 || row >= GridHeight)
                throw new ArgumentOutOfRangeException(nameof(row));
        }
    }
