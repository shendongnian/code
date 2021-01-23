    public class Program
    {
    	public static void Main()
    	{
    		int r=5;
    		_ = r==5 ? r=0 : 0;
    		Console.WriteLine($"{r}");
    		// outputs 0
    	}
    }
