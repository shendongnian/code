    public abstract class MessageSenderBase<T> : IMessageSender where T : class, IMessageData, new()
    {
        public MessageSenderBase() {
        }
    
        protected abstract Task<T> BuildType();
    
        public async Task SendMessage() {
            var message = await BuildType();
            Console.WriteLine($"Sending {JsonConvert.SerializeObject(message)}");
            await Task.FromResult(0);
        }
    }
