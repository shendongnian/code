    public class AlertConsumer : 
        IConsumer<IAlert>,
        IConsumer<IAlertExt>
    {
        public async Task Consume(ConsumeContext<IAlert> context){
           ...
        }
        public async Task Consume(ConsumeContext<IAlertExt> context){
            ...
        }
    }
