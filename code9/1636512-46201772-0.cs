    public class MessageDataBase
    {
        public string MessageID { get; set; }
        public string Date { get; set; }
        public bool IsSent { get; set; }
    }
    public class MessageData : MessageDataBase
    {
        public string EmployeeInfo { get; set; }
    }
    public class MultiMessageData : MessageDataBase
    {
        public byte MessageType { get; set; }
        public string MessageTypeString { get; set; }
        public string Platform { get; set; }
        public string EmployeeInfo { get; set; }
    }
    public class SocialData : MessageDataBase
    {
        public bool IsReceived { get; set; }
        public byte MessageType { get; set; }
        public string MessageTypeString { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
    }
