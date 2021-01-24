    Conversation.UpdateContainer(
        builder =>
        {
            builder.RegisterType<ActivityLogger>().AsImplementedInterfaces().InstancePerDependency();
                        
            builder
                .RegisterType<InterceptLogPostToBot>()
                .Keyed<IPostToBot>(typeof(LogPostToBot));
    
        });
    
    public class InterceptLogPostToBot: IPostToBot
    {
        private readonly IPostToBot inner;
        private readonly IActivityLogger logger;
        public InterceptLogPostToBot(IPostToBot inner, IActivityLogger logger)
        {
            SetField.NotNull(out this.inner, nameof(inner), inner);
            SetField.NotNull(out this.logger, nameof(logger), logger);
        }
    
        async Task IPostToBot.PostAsync(IActivity activity, CancellationToken token)
        {
            await this.logger.LogAsync(activity);
    
            //translate here, after the logging is complete
    
            await inner.PostAsync(activity, token);
        }
    }
