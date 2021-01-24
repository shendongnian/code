    static void Main(string[] args)
    {
        try
        {
            Task.Run(async () =>
            {
                try
                {
                    var task = Task.Run(() => throw new Exception("hi"));
                    await task;                        
                }
                catch (Exception e)
                {
                    Console.WriteLine("Async...");
                    throw;
                }
                
            }).Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine("Non Async");
            Console.WriteLine(e);
        }            
    }
