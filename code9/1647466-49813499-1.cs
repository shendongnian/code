    [Export("messaging:didReceiveRegistrationToken:")]
        public void DidReceiveRegistrationToken(Messaging messaging, string fcmToken)
        {
            // Monitor token generation: To be notified whenever the token is updated.
            LogInformation(nameof(DidReceiveRegistrationToken), $"Firebase registration token: {fcmToken}");
            // TODO: If necessary send token to application server.
            // Note: This callback is fired at each app startup and whenever a new token is generated.
        }
        // You'll need this method if you set "FirebaseAppDelegateProxyEnabled": NO in GoogleService-Info.plist
        //public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
        //{
        //  Messaging.SharedInstance.ApnsToken = deviceToken;
        //}
        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            // Handle Notification messages in the background and foreground.
            // Handle Data messages for iOS 9 and below.
            // If you are receiving a notification message while your app is in the background,
            // this callback will not be fired till the user taps on the notification launching the application.
            // TODO: Handle data of notification
            // With swizzling disabled you must let Messaging know about the message, for Analytics
            //Messaging.SharedInstance.AppDidReceiveMessage (userInfo);
            if(ConnectionClass.CompanyID != null)
            {
                SyncData.SyncDataDB();
            }
            //FirebasePushNotificationManager.CurrentNotificationPresentationOption = UNNotificationPresentationOptions.Alert;
            FirebasePushNotificationManager.DidReceiveMessage(userInfo);
            //HandleMessage(userInfo);
            // Print full message.
            //LogInformation(nameof(DidReceiveRemoteNotification), userInfo);
            //completionHandler(UIBackgroundFetchResult.NewData);
        }
        [Export("messaging:didReceiveMessage:")]
        public void DidReceiveMessage(Messaging messaging, RemoteMessage remoteMessage)
        {
            // Handle Data messages for iOS 10 and above.
            HandleMessage(remoteMessage.AppData);
            LogInformation(nameof(DidReceiveMessage), remoteMessage.AppData);
        }
        void HandleMessage(NSDictionary message)
        {
            if (MessageReceived == null)
                return;
            MessageType messageType;
            if (message.ContainsKey(new NSString("aps")))
                messageType = MessageType.Notification;
            else
                messageType = MessageType.Data;
            var e = new UserInfoEventArgs(message, messageType);
            MessageReceived(this, e);
        }
        public static void ShowMessage(string title, string message, UIViewController fromViewController, Action actionForOk = null)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (obj) => actionForOk?.Invoke()));
                fromViewController.PresentViewController(alert, true, null);
            }
            else
            {
                var alert = new UIAlertView(title, message, null, "Ok", null);
                alert.Clicked += (sender, e) => actionForOk?.Invoke();
                alert.Show();
            }
        }
        void LogInformation(string methodName, object information) => Console.WriteLine($"\nMethod name: {methodName}\nInformation: {information}");
