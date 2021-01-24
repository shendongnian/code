    static void Main (string [] args)
    {
        const int PEEK_TIME = 5;
        const int SECOND = 1000;
    
        var task = Task.Run(()=> 
        	{
        		Console.WriteLine ("Work started...");
        		Thread.Sleep(PEEK_TIME*SECOND);
        		Console.Clear();
        	});
        task.Wait();
        Console.WriteLine ("Work done.");
        Console.ReadLine ();
    }
