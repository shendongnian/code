    class PointEqualityComparer : IEqualityComparer<Point>
    {
    	public bool Equals(Point p1, Point p2) { return p1.X == p2.X && p1.Y == p2.Y; }
    
    	public int GetHashCode(Point p) { return p.X.GetHashCode() *31 + p.Y.GetHashCode()*23; }
    }
