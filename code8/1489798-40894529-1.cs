    sbc.ReceiveEndpoint("input_error", x =>
    {
        // this prevents extra message bindings from being created
        x.BindMessageExchanges = false;
        x.Consumer<MyMover>(() => new MyMover(inputQueueAddress);
    });
    public class MyMover : 
        IConsumer<ClaimsMessage>
    {
        public async Task Consume(ConsumeContext<ClaimsMessage> context)
        {
            try
            {
                var endpoint = await context.GetSendEndpoint(_inputQueueAddress);
                await endpoint.Send<ClaimsMessage>(context.Message);
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }
    }
