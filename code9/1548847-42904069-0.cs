    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(new Gold(10000)); 		//10000
    		Console.WriteLine(new Gold(100000)); 		//100000
    		Console.WriteLine(new Gold(1000000)); 		//1 mln.
    		Console.WriteLine(new Gold(10000000)); 		//10 mln.
    		Console.WriteLine(new Gold(100000000)); 	//100 mln.
    		Console.WriteLine(new Gold(1000000000)); 	//1 bln.
    		Console.WriteLine(new Gold(1500000000)); 	//1.5 bln.
    	}
    }
    
    public class Gold
    {
    	public decimal Value {get;set;}	
    	
    	public Gold(decimal value)
    	{
    		Value = value;	
    	}
    	
    	public override string ToString()
        {
    		if(Value>=1000000000) return $"{Value/1000000000} bln.";
    		if(Value>=1000000) return $"{Value/1000000} mln.";
          	return Value.ToString();
        }
    }
