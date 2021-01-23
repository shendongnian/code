    static void Main(string[] args)
    {
        var recvr = PeopleGenerator.PeopleGeneratorFactory.CreatePeopleDataReceiver();
        recvr.PeopleDataReady += new EventSubscriber();
       
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
