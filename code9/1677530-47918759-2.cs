     public class Message
    {
        //Message attributes
    }
    public class Headers
    {
    }
    public class Host
    {
        public string machineName { get; set; }
        public string processName { get; set; }
        public int processId { get; set; }
        public string assembly { get; set; }
        public string assemblyVersion { get; set; }
        public string frameworkVersion { get; set; }
        public string massTransitVersion { get; set; }
        public string operatingSystemVersion { get; set; }
    }
    public class TotalMessage
    {
        public string messageId { get; set; }
        public string correlationId { get; set; }
        public string conversationId { get; set; }
        public string sourceAddress { get; set; }
        public string destinationAddress { get; set; }
        public IList<string> messageType { get; set; }
        public Message message { get; set; }
        public Headers headers { get; set; }
        public Host host { get; set; }
    }
