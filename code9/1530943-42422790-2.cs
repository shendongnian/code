    [assembly: Xamarin.Forms.Dependency(typeof (NotificationService))]
    namespace App.iOS.Notifications
    {
        public class NotificationService : INotificationService
        {
    
            public string Token
            {
                get
                {
                    return NSUserDefaults.StandardUserDefaults.StringForKey(NotificationKeys.TokenKey);
                }
    
            }
    
            public void Register()
            {
                if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
                {
                    UIUserNotificationType notificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
                    var settings = UIUserNotificationSettings.GetSettingsForTypes(notificationTypes, new NSSet());
                    UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
                    UIApplication.SharedApplication.RegisterForRemoteNotifications();
                }
                else
                {
                    UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                    UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
                }
            }
    
        }
    
    }
