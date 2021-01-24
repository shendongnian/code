    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class PointCollection
    {
        public List<Point> collection { get; set; }
        public Point this[int x, int y]
        {
            get => collection.FirstOrDefault(item => item.X == x && item.Y == y);
        }
    }
