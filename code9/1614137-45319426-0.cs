        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            UNUserNotificationCenter center = UNUserNotificationCenter.Current;
            center.RequestAuthorization(UNAuthorizationOptions.Alert, (bool a, NSError error) => { });
            center.GetNotificationSettings((UNNotificationSettings setting) => {});
            registerNotification(2);
            return true;
            
        }
        public void registerNotification(int alertTime)
        {
            UNMutableNotificationContent content = new UNMutableNotificationContent();
            content.Body = "body";
            content.Title = "title";
            content.Sound = UNNotificationSound.Default;
            UNTimeIntervalNotificationTrigger trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(alertTime, false);
            UNNotificationRequest request = UNNotificationRequest.FromIdentifier("ABC", content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (NSError error) => {
                Window.RootViewController.PresentViewController(new ViewController1(), true ,null);
            });
        }
