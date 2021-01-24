	public static class PubSubTest
    {
        public static void Start()
        {
            Console.WriteLine("Starting PubSubTest");
            using (var activator = new BuiltinHandlerActivator())
            {
                var bus = Configure
                    .With(activator)
                    .Transport(t => t.UseRabbitMq("amqp://guest:guest@192.168.3.50", "MessagingTest").Prefetch(1))
                    .Routing(r => r.TypeBased())
                    .Start();
                Observable
                    .Timer(TimeSpan.Zero, TimeSpan.FromSeconds(10))
                    .Subscribe(_ => bus.Publish(new TimeEvent(DateTime.Now)).Wait());
                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
