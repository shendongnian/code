    public class NotifyEntry
    {
        public NotifyType Type { get; set; }
        public string Text { get; set; }
    }
    public enum NotifyType
    {
        Success,
        Information,
        Warning,
        Error
    }
