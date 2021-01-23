    static void Main(string[] args)
    {
    	var a = new ActionBlock<int>(async (messageNumber) => 
    	{
    		await Task.Delay(messageNumber * 1000);
            Console.WriteLine(messageNumber);
	    });
	
    	a.Post(5);
        Console.WriteLine("5 sent");
        a.Post(2);
        Console.WriteLine("2 sent");
        a.Post(1);
        Console.WriteLine("1 sent");
        a.Post(4);
        Console.WriteLine("4 sent");
        Console.WriteLine("all sent");
        Console.ReadLine();
    }
