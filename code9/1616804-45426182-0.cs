    static void Main(string[] args)
    {
    	var array = new string[] { "stackoverflower", "friend", "howsitgoin" };
    
    	Console.Write("Hello ");
    	foreach (var item in array)
    	{
    		if (item.Equals("friend"))
    		{
    			Console.ForegroundColor = ConsoleColor.Red;
    			Console.Write("{0} ", item);
    			Console.ForegroundColor = ConsoleColor.Gray;
    		}
    		else
    		{
    			Console.Write("{0} ", item);
    		}
    	}
    	Console.Write("with you");
    	Console.ReadKey();
    }
