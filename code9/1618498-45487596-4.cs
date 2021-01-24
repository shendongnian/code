    public class MyClass
    {
    	public static string operator +(MyClass left, double right)
    	{
    		return "";
    	}
    }
    
    TypeOfAddition<string, int>().Dump();     // System.String
    TypeOfAddition<int, double>().Dump();     // System.Double
    TypeOfAddition<float, double>().Dump();   // System.Double
    TypeOfAddition<MyClass, double>().Dump(); // System.String
