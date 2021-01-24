    namespace Code
    {
        using Microsoft.Bot.Builder.Dialogs;
        using Microsoft.Bot.Builder.Dialogs.Internals;
        using Microsoft.Bot.Connector;
    
        /// <summary>
        /// Activity mapper that automatically populates activity.speak for speech enabled channels.
        /// </summary>
        public sealed class TextToSpeakActivityMapper : IMessageActivityMapper
        {
            public IMessageActivity Map(IMessageActivity message)
            {
                // only set the speak if it is not set by the developer.
                var channelCapability = new ChannelCapability(Address.FromActivity(message));
    
                if (channelCapability.SupportsSpeak() && string.IsNullOrEmpty(message.Speak))
                {
                    message.Speak = message.Text;
                }
    
                return message;
            }
        }
    }
