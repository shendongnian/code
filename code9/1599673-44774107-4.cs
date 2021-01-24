    public class MySocketService : IService
    {
        public async Task DoSomething(string parameter)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
            var random = new Random();
            int randomNumber = 2;
    
            while (((IChannel)callback).State == CommunicationState.Opened)
            {
                await callback.SendMessageBack("Call back message:" + randomNumber);
                randomNumber += random.Next(10);
                await Task.Delay(1000);
            }
        }
    }
