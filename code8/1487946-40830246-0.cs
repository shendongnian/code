    static void Main(string[] args)
    {
        var message = "test";
        Task task = new Task(PrintMessage, message); 
        task.Start();
        Console.ReadKey();
    }
    static void PrintMessage(object messageObj)
    {
        var message = messageObj as string;
        Console.WriteLine(message);
    }
