    public class StoreLastActivity : IBotToUser
    {
        private readonly IBotToUser inner;
    
        public StoreLastActivity(IBotToUser inner)
        {
            SetField.NotNull(out this.inner, nameof(inner), inner);
        }
    
        public IMessageActivity MakeMessage()
        {
            return this.inner.MakeMessage();
        }
    
        public async Task PostAsync(IMessageActivity message, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Save the message here!!!
    
            await this.inner.PostAsync(message, cancellationToken);
        }
    }
