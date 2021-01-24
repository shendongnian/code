    public class Point
    {
        int x, y;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
    }
    public class Rectangle
    {
        Point p1, p2;
        public Point P1 { get { return p1; } set { p1 = value; } }
        public Point P2 { get { return p2; } set { p2 = value; } }
    }
    Rectangle r = new Rectangle 
    {
        P1 = new Point { X = 0, Y = 1 },
        P2 = new Point { X = 2, Y = 3 }
    };
