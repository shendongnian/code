    using System;
    class Example
    {
    	static void Main()
    	{
    		DateTime localDateTime, univDateTime;
    		Console.WriteLine("Enter a date and time.");
    		string strDateTime = Console.ReadLine();
    		try {
    			localDateTime = DateTime.Parse(strDateTime);
        		univDateTime = localDateTime.ToUniversalTime();
        		Console.WriteLine("{0} local time is {1} universal time.",localDateTime,univDateTime); 
    		}
    		catch (FormatException) {
    			Console.WriteLine("Invalid format.");
    			return;
    		}
    		Console.WriteLine("Enter a date and time in universal time.");
    		strDateTime = Console.ReadLine();
    		try {
    			univDateTime = DateTime.Parse(strDateTime);
        		localDateTime = univDateTime.ToLocalTime();
        		Console.WriteLine("{0} universal time is {1} local time.", univDateTime,localDateTime); 
    		}
    		catch (FormatException) {
    			Console.WriteLine("Invalid format.");
    			return;
    		}
    	}
    }
