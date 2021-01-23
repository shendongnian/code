    public class PointComparer : IEqualityComparer<Point>
    {
    	public bool Equals(Point a, Point b)
    	{
    		return a.HorizontalPosition == b.HorizontalPosition && a.VerticalPosition == b.VerticalPosition;
    	}
    
    	public int GetHashCode(Point p)
    	{
    		unchecked
		    { 
			    return (p.HorizontalPosition * 397) ^ p.VerticalPosition;
		    }
    	}
    }
    // ...
    List<Point> intersection = first.Intersect(second, new PointComparer()).ToList();
