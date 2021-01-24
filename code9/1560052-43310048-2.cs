    public class Program
    {
    	public static void Main()
    	{
    		AsyncMain().Wait();
    	}
    	
    	public static async Task AsyncMain()
    	{
    		int a = 500;
    		int b = 10;
    		var results = await TimeMeasurer.Start(() => Function(a,b));
    		Console.WriteLine("Waited: {0}", results.Duration.TotalSeconds);
    		Console.WriteLine("Result: {0}", results.Result);
    	}
    	
    	public static async Task<int> Function(int a, int b)
    	{
    		var total = a + b;
    		await Task.Delay(total);
    		return total;
    	}
    }
