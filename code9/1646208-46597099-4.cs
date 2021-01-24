    public interface INotification
    {
        void Notify(string Action, int OrderID);
        bool AppliesTo(string NotificationName);
    }
    public interface INotificationStrategy
    {
        void Notify(string NotificationName, string Action, int OrderID);
    }
