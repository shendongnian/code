    static void Test1()
    {
    	string s = "", make = "", model = "";
    	int ID, year;
    
    	Console.Write("What would you like to do ? Enter option between 1 or 2 : ");
    	//Console.ReadLine() will take the all the characters typed by the user before enter key is hit.
    	//These characters will be assigned to a string s.
    	//If you want to read next character use Console.Read(). 
        //Note: Its returns an int rather than byte or string.
    	//since your if condition matches it with "1", you can use ReadLine()
    
    	s = Console.ReadLine();
    	if (s == "1")
    	{
    		string consoleLine;
    		bool validInput = false;
    
    		//you can create a function for the validation and re-enter
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
    		} while (!validInput);
    
    		validInput = false;
    		do
    		{
    			Console.WriteLine("Enter the Year: ");
    			consoleLine = Console.ReadLine();
    			//check for validity
    			if (int.TryParse(consoleLine, out year))
    			{
    				//assuming ID should be between 1 and 10
    				if (year > 0 && year < 2021)
    				{
    					validInput = true;
    				}
    				else
    					Console.Write("Year should be between 1 and 2020. Re-");
    			}
    			else
    			{
    				Console.WriteLine("Year should be an integer. Re-");
    			}
    		} while (!validInput);
    
    		validInput = false;
    		do
    		{
    			Console.WriteLine("Enter the vehicle make: ");
    			make = Console.ReadLine();
    
    			if (make.Length > 0)
    			{
    				validInput = true;
    			}
    			else
    				Console.Write("Vehicle Make should be a valid text. Re-");
    		} while (!validInput);
    
    		validInput = false;
    		do
    		{
    			Console.WriteLine("Enter the vehicle model: ");
    			model = Console.ReadLine();
    
    			if (model.Length > 0)
    			{
    				validInput = true;
    			}
    			else
    				Console.Write("Vehicle Model should be a valid text. Re-");
    		} while (!validInput);
    
    
    		//here you have received all input
    		//now assign to Vehicle
    		var vehicle = new Vehicle
    		{
    			Id = ID,
    			Make = make,
    			Year = year,
    			Model = model
    		};
    
    		//Below code shows you that values are stored in the object vehicle
    		Console.WriteLine("Vehicle details stored in the object vehicle");
    		Console.WriteLine("Vehicle Id = " + vehicle.Id.ToString());
    		Console.WriteLine("Vehicle Year = " + vehicle.Year.ToString());
    		Console.WriteLine("Vehicle Make = " + vehicle.Make);
    		Console.WriteLine("Vehicle Model = " + vehicle.Model);
    
    		//You have not shown where you have declared the List<Vehicle> to
    		//store the collection of Vehicles.
    		//You might have implemented VehicleService. So you need to search the 
    		//Id in the List of Vehicle and if found use Update() else use Create()
    		//through the service implementation.
    	}
    
    	Console.WriteLine("Done. Press enter to Exit.");
    	Console.ReadKey();
    }
