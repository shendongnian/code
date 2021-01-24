    static void Main(string[] args)
    {
        //Run producer  thread
        Task t1 = Task.Run(new Action(ReadDataFromTable));
        //Run consumer  thread
        Task t2 = Task.Run(new Action(WriteDataToText));
    
        Task.WaitAll(t1, t2);
        Console.WriteLine("all completed");
    }
