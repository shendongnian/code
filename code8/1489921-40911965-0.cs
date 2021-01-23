    [Serializable()]
    public class HandledException : Exception
    {
        public bool Handled { get; set; }
        
        public HandledException(string Message)
            : base(Message)
        {
        }
    }
