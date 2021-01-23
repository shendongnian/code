    class Program
    {
        static void Main(string[] args)
        {
            var subject = new BehaviorSubject<ConnectionState>(ConnectionState.Disconnected);
            var getCredentials = subject.Where(cs => cs == ConnectionState.RequiresCredentials)
                .Select(cs =>
                {
                    Console.WriteLine("Enter username");
                    var userName = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    var password = Console.ReadLine();
                    return Tuple.Create(userName, password);
                });
            using (var subscription = getCredentials.Subscribe())
            {
                Console.WriteLine("Changing to Connecting...");
                subject.OnNext(ConnectionState.Connecting);
                Console.WriteLine("Changing to RequiresCredentials...");
                subject.OnNext(ConnectionState.RequiresCredentials);
                Console.WriteLine("Connected.");
                subject.OnNext(ConnectionState.Connected);
            }
        }
    }
    enum ConnectionState
    {
        Disconnected,
        Connected,
        Connecting,
        RequiresCredentials
    }
