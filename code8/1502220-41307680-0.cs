    static void Main(string[] args)
    {
    	Hashtable ht = GetID(); // Use hashtable to concate 2 parameters
    	Console.WriteLine("Your id is {0} and your password is {1}", ht["id"], ht["pass"]);            
    }
    // Change return type to Hashtable so it can return 2 concate parameter
    public static Hashtable GetID()
    {
    	Hashtable ht = new Hashtable();
    	Console.WriteLine("Please enter your ID");
    	int id = int.Parse(Console.ReadLine());
    	Console.WriteLine("You entered {0} as the id \t, is this correct? Y/N", id);
    	string response = Console.ReadLine();
        // Store Password from here
    	string pass = "";
    	switch (response)
    	{
    		case "N":
    			GetID();
    			break;
    		case "Y":
    			Console.WriteLine("Accepted");
    			pass = GetPass(id);
    			break;
    		default:
    			Console.WriteLine("Incorrect answer");
    			break;
    	}
        // Adding 2 parameters
    	ht["id"] = id;
    	ht["pass"] = pass;
    	return ht;
    }
    // No need of ref
    public static string GetPass(int id)
    {
    	Console.WriteLine("Please enter your password");
    	string password = Console.ReadLine();
    	Console.WriteLine("You entered {0} as the id \t, is this correct? Y/N", password);
    	string response = Console.ReadLine();
    	switch (response)
    	{
    		case "N":
    			GetPass(ref id);
    			break;
    		case "Y":
    			Console.WriteLine("Accepted");
    			break;
    		default:
    			Console.WriteLine("Incorrect answer");
    			break;
    	}
    	return password;
    }
