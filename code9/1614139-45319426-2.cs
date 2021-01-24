        UNDelegate _delegate;
        public override UIWindow Window
        {
            get;
            set;
        }
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            UNUserNotificationCenter center = UNUserNotificationCenter.Current;
            _delegate = new UNDelegate();
            center.Delegate = _delegate;
            center.RequestAuthorization(UNAuthorizationOptions.Alert, (bool a, NSError error) => { });
            center.GetNotificationSettings((UNNotificationSettings setting) => {});
            registerNotification();
            return true; 
        }
        public void registerNotification()
        {
            UNMutableNotificationContent content = new UNMutableNotificationContent();
            content.Body = "body";
            content.Title = "title";
            content.Sound = UNNotificationSound.Default;
            NSDateComponents components = new NSDateComponents();
            components.Weekday = 2;
            components.Hour = 8;
            UNCalendarNotificationTrigger trigger = UNCalendarNotificationTrigger.CreateTrigger(components, true);
            UNNotificationRequest request = UNNotificationRequest.FromIdentifier("ABC", content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (NSError error) => {
                
            });
        }
        public class UNDelegate : UNUserNotificationCenterDelegate
        {
            public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
            {
                completionHandler(UNNotificationPresentationOptions.Sound | UNNotificationPresentationOptions.Alert);
            }
            public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response,  Action completionHandler)
            {
                AppDelegate app = (AppDelegate)UIApplication.SharedApplication.Delegate;
                app.Window.RootViewController.PresentViewController(new ViewController1(), true, null);
            }
        }
