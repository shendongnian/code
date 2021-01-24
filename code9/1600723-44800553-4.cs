    public static void Main()
    {
    	int numberOfYears = GetYears();
    	
    	Console.WriteLine("Good work, years = " + numberOfYears);
    }
    
    public static int GetYears()
    {
    	Console.WriteLine("Enter the number of years:");
    	string inputYears = Console.ReadLine();
    	int years;
    	while(!(Int32.TryParse(inputYears, out years)) 
    	      || (years < 1  || years > 10))		 	   
    	{
    		Console.WriteLine("Not a valid ammount, higher than 1, lower than 10!"); 
            Console.WriteLine("Please enter a new number");
    		inputYears = Console.ReadLine(); 
    	} 
    	
    	return years;
    }
