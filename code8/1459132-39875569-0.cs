    public class Point
    {
    	public char HorizontalPosition { get; set; }
    	public int VerticalPosition { get; set; }
    
    	public Point(char horizontalPosition, int verticalPosition)
    	{
    		HorizontalPosition = char.ToUpper(horizontalPosition);
    		VerticalPosition = verticalPosition;
    	}
    
    	public override int GetHashCode()
    	{
    		return (HorizontalPosition.GetHashCode() + VerticalPosition.GetHashCode());
    	}
    
    	protected bool Equals(Point other)
    	{
    		return Equals(HorizontalPosition, other.HorizontalPosition) && Equals(VerticalPosition, other.VerticalPosition);
    	}
    
    	public override bool Equals(object obj)
    	{
    		if (ReferenceEquals(null, obj)) return false;
    		if (ReferenceEquals(this, obj)) return true;
    		if (obj.GetType() != this.GetType()) return false;
    		return Equals((Point)obj);
    	}
    }
