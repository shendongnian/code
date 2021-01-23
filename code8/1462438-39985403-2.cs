    public class GrossException : Exception
    {
        public GrossException() : base("Eww, gross") { }
        protected GrossException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        protected GrossException(string message) : base(message) { }
    }
