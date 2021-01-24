    string s, make, model;
    int ID, year;
    
    Console.Write("What would you like to do ? Enter option between 1 or 2 : ");
    s = Console.ReadLine();
    if (s == "1")
    {
    	string consoleLine;
    	bool validInput = false;
    	do
    	{
    		Console.WriteLine("Enter the vehicle ID: ");
    		consoleLine = Console.ReadLine();
    		//check for validity
    		if (int.TryParse(consoleLine, out ID))
    		{
    			//assuming ID should be between 1 and 10
    			if (ID > 0 && ID < 11)
    			{
    				validInput = true;
    			}
    			else
    				Console.Write("Vehicle ID should be between 1 and 10. Re-");
    		}
    		else
    		{
    			Console.WriteLine("Vehicle ID should be an integer. Re-");
    		}
    	} while (! validInput);
    
    	do
    	{
    		Console.WriteLine("Enter the vehicle make: ");
    		consoleLine = Console.ReadLine();
    		
    		if (consoleLine.Length > 0)
    		{
    			validInput = true;
    		}
    		else
    			Console.Write("Vehicle make should be a valid text. Re-");
    	} while (!validInput);
    	
    	:
    	:
    	
    }
