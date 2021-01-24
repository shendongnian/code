	class TimeEventHandler : IHandleMessages<TimeEvent>
    {
        public async Task Handle(TimeEvent message)
        {
            Console.WriteLine(message.Time);
            //await Program.Activator.Bus.Reply("Ja danke");
        }
    }
    class Program
    {
        public static BuiltinHandlerActivator Activator;
        static void Main(string[] args)
        {
            using (Activator = new BuiltinHandlerActivator())
            {
                Activator.Register(() => new TimeEventHandler());
                var bus = Configure
                    .With(Activator)
                    .Transport(t => t.UseRabbitMq("amqp://guest:guest@192.168.3.50",
                        $"ConsumerPrototype").Prefetch(1))
                    .Routing(r => r.TypeBased())
                    .Start();
                bus.Subscribe<TimeEvent>();
                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
                // Without the unsubscribe we have a durable subscriber, see http://www.enterpriseintegrationpatterns.com/patterns/messaging/DurableSubscription.html
                //bus.Unsubscribe<TimeEvent>();
            }
        }
    }
