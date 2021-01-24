    class Case2MapWithoutCSharp7
    {
        Tile[,] tiles;
        public Tile this[int x, int y]
        {
            get { return tiles[x, y]; }
            set { tiles[x, y] = value; }
        }
    }
