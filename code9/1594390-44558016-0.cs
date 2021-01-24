    void Main()
    {
    	Console.WriteLine("Not instantiated yet!");
    	Stat.A();
    }
    
    // Define other methods and classes here
    
    static class Stat
    {
    	static Stat()
    	{
    		Console.WriteLine("Instantiated!");		
    	}
    	
    	public static void A()
    	{
    		Console.WriteLine("A was called!");
    	}
    }
