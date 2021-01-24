	class FaultedTimeEventHandler : IHandleMessages<TimeEvent>
    {
        public async Task Handle(TimeEvent message)
        {
            throw new Exception("That should not have happened");
        }
    }
    class Program
    {
        public static BuiltinHandlerActivator Activator;
        static void Main(string[] args)
        {
            using (Activator = new BuiltinHandlerActivator())
            {
                Activator.Register(() => new FaultedTimeEventHandler());
                var bus = Configure
                    .With(Activator)
                    .Transport(t => t.UseRabbitMq("amqp://guest:guest@192.168.3.50",
                        $"ConsumerPrototype").Prefetch(1))
                    .Routing(r => r.TypeBased())
                    .Start();
                bus.Subscribe<TimeEvent>();
                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
