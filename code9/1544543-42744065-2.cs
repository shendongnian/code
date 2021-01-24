    struct WallAddress
    {
        public int X0 { get; }
        public int Y0 { get; }
        public int X1 { get; }
        public int Y1 { get; }
        public WallAddress(int x0, int y0, int x1, int y1)
        {
            // Optional, not shown here:
            // Validate addresses to make sure they represent adjacent tiles
            if (x1 < x0 || (x1 == x0 && y1 < y0))
            {
                int xT = x0, yT = y0;
                x0 = x1;
                x1 = xT;
                y0 = y1;
                y1 = yT;
            }
            X0 = x0;
            Y0 = y0;
            X1 = x1;
            Y1 = y1;
        }
    }
    Dictionary<WallAddress, Wall> walls = new Dictionary<WallAddress, Wall>();
