    using System;
    public class Test
    {
    	public static string[] MyFunc()
    	{
    		int x = 1;
            string answer = "yes";
    
            string[] playerNumber = new string[x];
            while (answer == "yes")
            {
                Console.Write("Enter a number   :   ");
                string y = Console.ReadLine();
    			
                playerNumber[x-1] = y;
    			x++;
    			Array.Resize(ref playerNumber, x);
                
                Console.Write("Would you like to enter another number? (y/n)");
                answer = Console.ReadLine();
    
                Console.WriteLine();
            }
            
            return playerNumber;
    	}
    	
    	public static void Main()
    	{
    		Console.WriteLine(MyFunc()[0]); // prints the first string
    		
    	}
    }
