    //This method will find a specific number within the array and check if it has already been entered
    public static void findData()
    {
    	double number;
    	Console.WriteLine("Find a number");
    	string input = Console.ReadLine();
    	// we use the same logic here as in the addData method to make sure the user input is a number
    	if (!double.TryParse(input, out number))
    	{
    		bool found = myArray.Contains(number);
    		if (found)
    			Console.WriteLine("Array has number {0}", number);
    		else
    			Console.WriteLine("Array doesn't have number {0}", number);
    	}
    	else
    	{
    		Console.WriteLine("Invalid input. Please enter a valid number");
    	}
    }
