    void Main()
    {
    	var dc = new DistanceConversion();
    	var miles = 4.5;
    	Console.WriteLine("{0} miles is {1} kilometres", miles, dc.MilesToKilometres(miles));
    }
    
    public class DistanceConversion
    {
    	public double MilesToKilometres(double miles)
    	{
    		return miles * 8.0 / 5.0;
    	}
    }
