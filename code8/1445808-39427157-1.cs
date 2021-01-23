    public class Test
    {
    	public static void Main()
    	{
    		Console.WriteLine(nameof(A.X));
    		Console.WriteLine(nameof(A.Y));  // works fine
    	}
     
    }
     
    public class A
    {
        public int X;
    	private int Y {get; set;}
    }
