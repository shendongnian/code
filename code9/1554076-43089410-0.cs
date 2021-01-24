    public class Entry
    {
    	public Entry(TimeSpan time, double x, double y)
    	{
    		Time = time;
    		X = x;
    		Y = y;
    	}
    
    	public TimeSpan Time { get; }
    	public double X { get; }
    	public double Y { get; }
    }
