    public interface IRequestExtensions
    {
        int NotificationId { get; set; }
        int StatusId { get; set; }
        string StatusCode { get; set; }
        string StatusMessage { get; set; }
        string Destination { get; set; }
        string BusinessProcessCode { get; set; }
        string MsgType { get; set; }
        string MessageId { get; set; }
    }
