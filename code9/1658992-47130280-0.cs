    	static void Main(string[] args)
        {
    	bool keepGoing = true;
    
    	while (keepGoing)
    	{
    		DoYourWork();
    		Console.WriteLine("Continue? Press any key to continue, N or n to exit:");
    		
    		var userWantsToContinue = Console.ReadLine();
    
    		keepGoing = userWantsToContinue?.ToUpper() != "N";
    	}
    }
