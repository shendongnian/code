    using System;
    using System.Collections.Generic;
    
    delegate bool MessageHandler(char countAlertStatus, char ageAlertSatus, char deltaAlertStatus, out string message);
    
    class Program
    {
        static void Main(string[] args)
        {
    		var handlers = new List<MessageHandler>();
    
    		//register lambda with array
    		handlers.Add(Handler1);
    
    		foreach (var handler in handlers)
    		{
                // some fake input to each handler C/-/-
    			if (handler('C', '-', '-', out string message))
    			{
    				Console.WriteLine("handled: " + message);
    			}
    		}
    
    		Console.WriteLine("Done...");
    		Console.Read();
        }
    
    	static bool Handler1(char countAlertStatus, char ageAlertSatus, char deltaAlertStatus, out string message)
    	{
    		if (countAlertStatus == 'C')
    		{
    			message = "Handled";
    
    			return true;
    		}
    		else
    		{
    			message = null;
    
    			return false;
    		}
    	}
    }
