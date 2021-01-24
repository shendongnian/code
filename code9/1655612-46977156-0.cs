    public static class Extender
    {
    	public static void ExtentionMethod(this Mother mother, int i)
    	{
    		Console.WriteLine($"Mother extention method {i}");
    	}
    
    	public static void ExtentionMethod(this Child child, int i)
    	{
    		Console.WriteLine($"Child extention method {i}");
    	}
    }
