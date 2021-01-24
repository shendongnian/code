    public class BigMessageConsumer : IConsumer<BigMessage>
    {
        public async Task Consume(ConsumeContext<BigMessage> context)
        {
            var mestype = await context.Message.messagetype.Value;
            var bigPayload = await context.Message.BigPayload.Value;
    
            // Do something with the big payload...
        }
    }
