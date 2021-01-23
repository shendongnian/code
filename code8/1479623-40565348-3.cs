    static void Main(string[] args)
        {
            var recvr = PeopleGenerator.PeopleGeneratorFactory.CreatePeopleDataReceiver();
            var subscriber = new EventSubscriber();
            recvr.PeopleDataReady += new subscriber.Handle;
           
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
