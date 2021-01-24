    public class DetailedException : Exception {
        public string DetailedMessage { get; }
        public DetailedException(string longMessage, string shortMessage) : base(shortMessage) {
            DetailedMessage = longMessage;
        }
    }
