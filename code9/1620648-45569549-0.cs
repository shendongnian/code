    static void Main(string[] args)
    {
    	string password = null;
    
    	do
    	{
    		Console.Write("Password: ");
    		password = Console.ReadLine();
    	}
    	while (string.IsNullOrWhiteSpace(password));
    
    	// do something with the password
    }
