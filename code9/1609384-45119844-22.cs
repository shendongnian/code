    private int[,] _world;
    private bool[,] _visited;
    [DebuggerDisplay("Coord({Row}, {Col})")]
    private struct Coord
    {
        public Coord(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public readonly int Row;
        public readonly int Col;
    }
