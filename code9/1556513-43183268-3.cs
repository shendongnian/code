    public class NotificationHelper : INotificationHelper
    {
        public bool SendNotification(INotifier obj)
        {
            return obj.Notify();
        }
    }
