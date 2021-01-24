    public class ExtendedArgumentOutOfRangeException : ArgumentOutOfRangeException
    {
        public string SystemMessage { get; }
    
        public ExtendedArgumentOutOfRangeException(string message, string value, string systemMessage) : base(message, value)
        {
            SystemMessage = systemMessage;
            // more here
        }
    }
