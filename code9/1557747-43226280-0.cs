    public class MyMessage {
        public DateTime Received { get; set; }
        public string Message { get; set; }
        public string DisplayString 
        {
            get { return this.ToString(); }
        }
        public string ToString() {
            return "[" + Received.ToShortTimeString() + "] " + Message;
        }
    }
