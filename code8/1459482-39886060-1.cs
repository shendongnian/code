    public class Tetromino
    {
        public static readonly Tetromino J = new Tetromino(new[,] { { false, false, true }, .... });
        public static readonly Tetromino L = new Terromino(new[,] { { true, false, false } .... });
        //and so on...
        private readonly bool[,] grid;
        private Tetromino(bool[,] shape) //disallow any other Terronimos from being built.
        {
             this.shape = shape;
             Width = shape.GetLength(0);
             Height = shape.GetLength(1);
        }
        public int Height { get; }
        public int Width { get; }
        public bool this[int row, int col] => shape[row, col];
    }
        
