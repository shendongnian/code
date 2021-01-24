	public static void Main()
	{
		
		Console.WriteLine("Enter salary range:");
		var low = GetIntFromUser("From:", "value must be an integer");
		var high = GetIntFromUser("To:", "value must be an integer");
		var range = new Range(low, high);
		Console.WriteLine("Salary entered is {0}", range);
	}
	
	public static int GetIntFromUser(string askFor, string error)
	{
		int result = 0;
		while(true)
		{
			Console.WriteLine(askFor);
			var input = Console.ReadLine();
			if(int.TryParse(input, out result))
		    {
				return result;
		    }
			Console.WriteLine(error);
		}
	}
