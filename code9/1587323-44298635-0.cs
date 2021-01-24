    public static void Main()
    	{
    		string Time = "4:30 AM";
        while (true)
        {
    		Console.WriteLine("{0}",DateTime.UtcNow.ToString("hh:mm tt"));
    // Prints 04:30 AM - so that is why it does not match 4:30 AM
            if (Time == DateTime.UtcNow.ToString("hh:mm tt"))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
    
                // Update Days -1 Where Service = 1
               
    			Console.WriteLine("I am In");
    
                Console.ResetColor();
                
            }
           Thread.Sleep(1000);
        }
    	}
