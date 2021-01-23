    using System;
    
    class MainClass {
    	public static void Main (string[] args) {
            var input = Console.ReadLine();
    		int value;
    		if ( int.TryParse( input, out value ) )
    		{
                //the user input is now stored in the 'value' variable
    			//and you can normally use it as a number
    		}
    		else
    		{
    			Console.WriteLine("::INVALID::")
    		}
    	}
    }
