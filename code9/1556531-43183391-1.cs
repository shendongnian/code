    public class NotificationHelper
    {
        public bool SendNotification(obj1 obj)
        {
            var sender = new SendSMS();
            return sender.Send(obj);
        }
        public bool SendNotification(obj1 obj)
        {
            var sender = new SendPush();
            return sender.Send(obj);
        }
        public bool SendNotification(obj1 obj)
        {
            var sender = new SendEmail();
            return sender.Send(obj);
        }
    }
