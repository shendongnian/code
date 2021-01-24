    [assembly:Dependency(typeof(NotificationService))]
    namespace TestMVVM.Droid
    {
        public class NotificationService : INotification
        {
            public void SetNotification(DateTime notificationDate, TimeSpan notificationTime)
            {
                Notification.Builder builder = new Notification.Builder (Xamarin.Forms.Forms.Context)
                    .SetContentTitle ("Test Notification")
                    .SetSmallIcon(Android.Resource.Drawable.AlertDarkFrame)
                    .SetWhen (Java.Lang.JavaSystem.CurrentTimeMillis ())
                    .SetDefaults (NotificationDefaults.Sound)
                    .SetContentText ("Notification from Xamarin Forms");
            }
        }
    } 
