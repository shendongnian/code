                if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
                {
                    // iOS 10 or later
                    var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
                    UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) =>
                    {
                        if (granted)
                        {
                            InvokeOnMainThread(() => {
                                UIApplication.SharedApplication.RegisterForRemoteNotifications();
                            });
                        }
                    });
    
                    // For iOS 10 display notification (sent via APNS)
                    UNUserNotificationCenter.Current.Delegate = ADSelf;
                }
                else
                {
                    // iOS 9 or before
                    var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
                    var settings = UIUserNotificationSettings.GetSettingsForTypes(allNotificationTypes, null);
                    UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
                }
