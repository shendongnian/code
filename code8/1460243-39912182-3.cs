    //This method will add numbers to the array
    public static void addData()
    {
    	double number;
    
    	for (int i = 0; i < myArray.Length; i++)
    	{
    		Console.WriteLine("Enter a number you would like to add");
    		// read user input
    		string input = Console.ReadLine();
    		// condition is true if user input is a number
    		if (double.TryParse(input, out number))
    			myArray[i] = number;
    		else
    			Console.WriteLine("Invalid input. Please enter a valid number");
    	}
    }
