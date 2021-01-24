    public class MessageListener
    {
        public void Start()
        {
            // Listen to rabbit QM and all the things.
        }
    }
    public static void Main(string[] args)
    {
        // Listen to messages.
        var messaging =  MessageListener();
        messaging.Start();
       
        // Configure web host and start it.
        var host = new WebHostBuilder()
            ...
            .Build();
        host.Run();
    }
