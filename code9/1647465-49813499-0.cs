    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            App.Configure ();
            // Register your app for remote notifications.
            if (UIDevice.CurrentDevice.CheckSystemVersion (10, 0)) {
                // For iOS 10 display notification (sent via APNS)
                UNUserNotificationCenter.Current.Delegate = this;
                var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
                UNUserNotificationCenter.Current.RequestAuthorization (authOptions, (granted, error) => {
                    Console.WriteLine (granted);
                });
            } else {
                // iOS 9 or before
                var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
                var settings = UIUserNotificationSettings.GetSettingsForTypes (allNotificationTypes, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);
            }
            UIApplication.SharedApplication.RegisterForRemoteNotifications ();
            Messaging.SharedInstance.Delegate = this;
            // To connect with FCM. FCM manages the connection, closing it
            // when your app goes into the background and reopening it 
            // whenever the app is foregrounded.
            Messaging.SharedInstance.ShouldEstablishDirectChannel = true;
            return true;
        }
