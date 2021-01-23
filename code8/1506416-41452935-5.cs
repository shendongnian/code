    public void sendNotification(NotificationEnum notificationType)
    {
         foreach(var action in notificationType.GetAllFlags())
         {
             action();
         }
    }
