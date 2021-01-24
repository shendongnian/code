    public class MyMessageConsumer : IConsumer<MyMessage>
    {
        private readonly Func<IConsumeContext<MyMessage>, TightCoupleProcess> factory;
    
        public MyMessageConsumer(Func<IConsumeContext<MyMessage>, TightCoupleProcess> factory)
        {
            _factory = factory;
        }
    
        public Task Consume(ConsumeContext<MyMessage> context)
        {
            var tcp = _factory(context);
            tcp.StartProcess();
        
            return Task.CompletedTask;
        }
    }
