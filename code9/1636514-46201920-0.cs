    public interface IMessageData
    {
        //Example required function for all MessageData classes
        void SetDate(DateTime date);
        void SetIsSent(bool date);
    }
    public abstract class BaseMessageData : IMessageData
    {
        public string MessageID { get; set; }
        public string Date { get; set; }
        public bool IsSent { get; set; }
        public BaseMessageData(string messageID)
        {
            MessageID=messageID;
        }
        public void SetDate(DateTime date)
        {
            Date = date.ToString("MM/dd/yyyy");
        }
        public void SetIsSent(bool sentStatus)
        {
            IsSent = sentStatus;
        }
    }
    public class MessageData : BaseMessageData, IMessageData
    {
        public string EmployeeInfo { get; set; }
    }
    public class MultiMessageData : MessageData,IMessageData
    {
        public byte MessageType { get; set; }
        public string MessageType { get; set; }
        public string Platform { get; set; }
    }
    public class SocialData : BaseMessageData, IMessageData
    {
        public bool IsReceived { get; set; }
        public byte MessageType { get; set; }
        //Can't have to properties named the same. 
        //public string MessageType { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
    }
