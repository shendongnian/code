    public class InterceptBotToUserTranslator : IBotToUser
    {
        private readonly IBotToUser inner;
        private readonly IActivityLogger logger;
        public InterceptBotToUserTranslator(IBotToUser inner, IActivityLogger logger)
        {
            SetField.NotNull(out this.inner, nameof(inner), inner);
            SetField.NotNull(out this.logger, nameof(logger), logger);
        }
        public IMessageActivity MakeMessage()
        {
            return inner.MakeMessage();
        }
    
        public async Task PostAsync(IMessageActivity message, CancellationToken cancellationToken)
        {
            //call the logger
            await this.logger.LogAsync(message);
            //TODO: Translate here
            //post to the next IBotToUser in the chain
            await inner.PostAsync((Activity)message, cancellationToken);
        }
    }
