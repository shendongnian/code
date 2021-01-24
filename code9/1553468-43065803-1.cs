    public class Program
    {
    	public static void Main()
    	{
    		var dateTime = DateTime.Now;
    		
    		Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name);
    		Console.WriteLine(dateTime.ToString(CultureInfo.InvariantCulture));		
    		Console.WriteLine(dateTime.ToString(new CultureInfo("en-us")));
    	}
    }
