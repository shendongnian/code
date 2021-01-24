    public static decimal[] PromptForDecimals(string[] array1)
    {
    	return
    		array1
    			.Select(x =>
    			{
    				Console.WriteLine(x);
    				string inputString = Console.ReadLine();
        			decimal input;
    				while (!decimal.TryParse(inputString, out input))
    				{
    					Console.WriteLine("Please enter a number value.");
    					inputString = Console.ReadLine();
    				}
    				return input;
    			})
    			.ToArray();
    }
