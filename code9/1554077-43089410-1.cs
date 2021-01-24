    public class Entry
    {
    	public Entry(TimeSpan time, double x, double y)
    	{
    		Time = time;
    		X = x;
    		Y = y;
    	}
    
	    public TimeSpan Time { get; private set; }
	    public double X { get; private set; }
	    public double Y { get; private set; } 
    }
