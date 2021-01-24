    private static void Main(string[] args)
    {
    	int number = 5;
    	bool isValid = VerifyNumber(number);
    	if (!isValid)
    		Console.WriteLine("Not valid.");
    	else
    		Console.WriteLine("Valid.");
    
    	Console.ReadKey();
    }
    
    private static bool VerifyNumber(int number)
    {
    	return number > 2;
    }
