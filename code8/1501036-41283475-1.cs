    class Board
    {
        public Square[,] board;
        public int n;
    
        public Board()
        {
            Console.Write("Enter the nuber of rows on column(int): ");
            n = int.Parse(Console.ReadLine());
            board = new Square[n, n];
            mines = (n * n) / 6;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = new Square(this, row, col);
                }
            }
            board[row, col].AddMine();
        }
    }
