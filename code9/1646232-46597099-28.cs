    public class NotificationStrategy : INotificationStrategy
    {
        private readonly IEnumerable<INotification> oNotifications;
        public MessageStrategy(IEnumerable<INotification> oNotifications)
        {
            if (oNotifications == null)
                throw new ArgumentNullException("oNotifications");
            this.oNotifications = oNotifications;
        }
        public void Notify(string NotificationName, string Action, int OrderID)
        {
            var notification = this.oNotifications
                .FirstOrDefault(x => x.AppliesTo(NotificationName));
            // Possible alternative: get multiple implementations and
            // then loop through them, executing each one.
            // var notifications = this.oNotifications
            //     .Where(x => x.AppliesTo(NotificationName)).ToArray();
            if (notification == null)
            {
                throw new Exception("No notification type registered for " + NotificationName);
            }
            notification.Notify(Action, OrderID);
        }
    }
