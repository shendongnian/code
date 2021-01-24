    static void Main(string[] args)
    {
        var task = Task.Run(() => chatterBotSession.Think(input));
        if (task.Wait(1000))
        {
            Console.WriteLine(task.Result);
        }
        else
        {
            Console.WriteLine("Couldn't get an answer in a timely manner");
        }
        Console.ReadLine();
    }
