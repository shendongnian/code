    List<Point> first = new List<Point> { new Point('a', 1), new Point('b', 2) };
                List<Point> second = new List<Point> { new Point('a', 1), new Point('b', 2) };
                List<Point> intersection = first.Intersect(second, new PointComparer()).ToList();
    
	public class Point 
    {
        public char HorizontalPosition { get; set; }
        public int VerticalPosition { get; set; }
        public Point(char horizontalPosition, int verticalPosition)
        {
            HorizontalPosition = char.ToUpper(horizontalPosition);
            VerticalPosition = verticalPosition;
        }
    }
    public class PointComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point x, Point y)
        {
            return (x.VerticalPosition == y.VerticalPosition && x.HorizontalPosition == y.HorizontalPosition);
        }
        public int GetHashCode(Point obj)
        {
            return (obj.HorizontalPosition.GetHashCode() + obj.VerticalPosition.GetHashCode());
        }
    }
