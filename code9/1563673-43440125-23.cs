    class Container
    {
        private Tile[] tiles = new Tile[] { new Tile { X = 10 } };
        public Tile this[int x]
        {
            get { return tiles[x]; }
            set { tiles[x] = value; }
        }
    }
    public struct Tile
    {
        public int X { get; set; }
        // Many more propeties
    }
