    public sealed class MicrosoftLoggingAdapter<T> : MicrosoftLoggingAdapter 
    {
        public MicrosoftLoggingAdapter(ILoggerFactory factory) 
            : base(factory.CreateLogger<T>()) { }
    }
