    public class NotificationStrategy : INotificationStrategy
    {
        private readonly INotification[] oNotificcations;
        public MessageStrategy(INotification[] oNotificcations)
        {
            if (oNotificcations == null)
                throw new ArgumentNullException("oNotificcations");
            this.oNotificcations = oNotificcations;
        }
        public void Notify(string NotificationName, string Action, int OrderID)
        {
            var notification = this.oNotificcations
                .FirstOrDefault(x => x.AppliesTo(NotificationName));
            if (notification == null)
            {
                throw new Exception("No notification type registered for " + NotificationName);
            }
            notification.Notify(Action, OrderID);
        }
    }
