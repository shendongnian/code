    public class SmsFactory
    {
        public ISMSServiceProvider Resolve(NotificationProvider provider) =>
            provider == NotificationProvider.Twilio 
                ? HostConfig.Resolve<TwilioProvider>()
                : HostConfig.Resolve<NexmoProvider>();
    }
    container.Register(c => new SmsFactory());
