    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		decimal val1 = 0m;
    		decimal val2 = 125580m;
    		
    
    		Console.WriteLine(val1.ToString("0.00"));
    		//Output 0.00
    		
    		Console.WriteLine(val2.ToString("0.00"));
    		//Output 125580.00
    		
    		//Money format
    		Console.WriteLine(val1.ToString("C"));		
    		//Output $0.00
    		
    		Console.WriteLine(decimalToFormattedString(val1));
    		//Output 0.00
    		
    		Console.WriteLine(decimalToFormattedString(val2));
    		//Output 125580.00
    	}
    	
    	public static string decimalToFormattedString(decimal myValue)
    	{	
    		return myValue.ToString("0.00");
    	}
    }
