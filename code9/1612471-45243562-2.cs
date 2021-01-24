    public struct Point {
        public double X { get; private set; }
        public double Y { get; private set; }
    
        public Point(double x, double y) {
            X = x;
            Y = y;
        }
    
        public Point(Point other) {
            X = other.X;
            Y = other.Y;
        }
    }
