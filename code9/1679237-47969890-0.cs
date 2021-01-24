    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int CHWTemp;
    		String inputStr = "17";
    	    int.TryParse(inputStr,out CHWTemp);
    
    
                if (CHWTemp >= 0 && CHWTemp <= 10)
                    {
                        Console.WriteLine("UPDATE Temperature SET Temp = 25 where id=12");
                    }
                    else if (CHWTemp >= 11 && CHWTemp <= 20)
                    {
                        Console.WriteLine("UPDATE Temperature SET Temp = 24 Where id=12");
                    }
                    else if (CHWTemp >= 21 && CHWTemp <= 40)
                    {
                        Console.WriteLine("UPDATE Temperature SET Temp = 23 where id=12");
                    }
                    else if (CHWTemp >= 41 && CHWTemp <= 60)
                    {
                        Console.WriteLine("UPDATE Temperature SET Temp = 22 where id=12");
                    }
                    else if (CHWTemp >= 61 && CHWTemp <= 80)
                    {
                        Console.WriteLine("UPDATE Temperature SET Temp = 21 where id=12");
                    }
                    else if (CHWTemp >= 81 && CHWTemp <= 100)
                    {
                        Console.WriteLine("UPDATE Temperature SET Temp = 20 where id=12");
                    }
            
    	}
    }
